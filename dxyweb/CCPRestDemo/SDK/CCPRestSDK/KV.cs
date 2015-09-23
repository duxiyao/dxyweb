using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            initSpecialKv(mData);
        }

        public bool isVerify()
        {
            return mVerify;
        }

        public Dictionary<string, object> getSpecialKv()
        {
            return mTmp;
        }

        public string getKvv()
        {
            string ret="";
            foreach (KeyValuePair<string, object> item in mTmp)
            {
                ret += item.Key.ToString() + "=" + item.Value.ToString() + ";";
            }
            return ret;
        }

        private void initSpecialKv(Dictionary<string, object> data)
        { 
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    initSpecialKv((Dictionary<string, object>)item.Value); 
                }
                else
                {
                    string key = toString(item.Key);
                    string value = toString(item.Value);
                    if (mKeys.Contains(key))
                    {
                        mVerify = true;
                        mTmp.Add(key, value);
                    }
                }
            } 
        }

        private string toString(object obj)
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
