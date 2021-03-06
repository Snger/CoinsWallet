﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TimemicroCore.CoinsWallet.Sdk;

namespace TimemicroCore.CoinsWallet.Api
{
    public abstract class AbstractApiService<Req, Resp> : IApiService
        where Req : CoinsWalletApiData
        where Resp : CoinsWalletApiRespData, new()
    {
        protected ApiServiceAppSettings AppSettings { get; set; }

        public abstract string Name { get; }

        public Type ReqType => typeof(Req);

        public abstract Resp Execute(Req req);

        public object Execute(object obj)
        {
            var req = (Req)obj;
            var resp = new Resp();
            try
            {
                if (!req.CheckTimestampOffset(TimeSpan.FromMinutes(-5), TimeSpan.FromMinutes(5)))
                {
                    resp.RespCode = "10001";
                    resp.RespMessage = "时间戳错误";
                    return resp;
                }
                if (!req.CheckSignByMD5(AppSettings.ApiKey))
                {
                    resp.RespCode = "10002";
                    resp.RespMessage = "签名错误";
                    return resp;
                }
                return Execute(req);
            }
            catch (Exception ex)
            {
                resp.RespCode = "99999";
                resp.RespMessage = "系统异常";
                return resp;
            }
        }
    }
}
