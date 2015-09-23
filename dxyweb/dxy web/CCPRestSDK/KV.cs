using System;
using System.Collections.Generic; 
using System.Text; 

namespace CCPRestSDK
{
    public class KV
    {
        private List<string> mKeys;
        private Dictionary<string, object> mData,mTmp;
        private bool mVerify = false;

        public KV(Dictionary<string, object> data, List<string> keys)
        {
            mData = data;
            mKeys = keys;
            mTmp = new Dictionary<string, object>();
            InitSpecialKv(mData);
        }

        public bool IsVerify()
        {
            return mVerify;
        }

        public Dictionary<string, object> GetSpecialKv()
        {
            return mTmp;
        }

        public string GetV(string key)
        {
            object obj = mTmp[key];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }

        public string GetKvv()
        {
            string ret="";
            foreach (KeyValuePair<string, object> item in mTmp)
            {
                ret += item.Key.ToString() + "=" + item.Value.ToString() + ";";
            }
            return ret;
        }

        private void InitSpecialKv(Dictionary<string, object> data)
        { 
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    InitSpecialKv((Dictionary<string, object>)item.Value); 
                }
                else
                {
                    string key = ToString(item.Key);
                    string value = ToString(item.Value);
                    if (mKeys.Contains(key))
                    {
                        mVerify = true;
                        mTmp.Add(key, value);
                    }
                }
            } 
        }

        private string ToString(object obj)
        {
            try
            {
                return obj.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
