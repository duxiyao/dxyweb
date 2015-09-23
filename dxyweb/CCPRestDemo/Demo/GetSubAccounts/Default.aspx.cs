﻿/*
 *  Copyright (c) 2014 The CCP project authors. All Rights Reserved.
 *
 *  Use of this source code is governed by a Beijing Speedtong Information Technology Co.,Ltd license
 *  that can be found in the LICENSE file in the root of the web site.
 *
 *   http://www.yuntongxun.com
 *
 *  An additional intellectual property rights grant can be found
 *  in the file PATENTS.  All contributing project authors may
 *  be found in the AUTHORS file in the root of the source tree.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetSubAccounts
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ret = null;

            CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
						//ip格式如下，不带https://
            bool isInit = api.init("sandboxapp.cloopen.com", "8883");
            api.setAccount(主帐号, 主帐号令牌);
            api.setAppId(应用ID);

            try
            {
                if (isInit)
                {
                    Dictionary<string, object> retData = api.GetSubAccounts(0, 100);
                    ret = getDictionaryData(retData);
                }
                else
                {
                    ret = "初始化失败";
                }
            }
            catch (Exception exc)
            {
                ret = exc.Message;
            }
            finally
            {
                Response.Write(ret);
            }
        }

        private string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else if (item.Value != null && item.Value.GetType() == typeof(List<object>))
                {
                    ret += item.Key.ToString() + "={";
                    foreach (object subItem in (List<object>)item.Value)
                    {
                        ret += "SunAccount={";
                        if (subItem.GetType() == typeof(Dictionary<string, object>))
                        {
                            ret += getDictionaryData((Dictionary<string, object>)subItem);
                        }
                        ret += "};";
                    }
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
    }
}