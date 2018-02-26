﻿using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimemicroCore.CoinsWallet.Network;
using TimemicroCore.CoinsWallet.Sdk.Ethereum;

namespace TimemicroCore.CoinsWallet.Quartz.Ethereum
{
    [DisallowConcurrentExecution]
    public class ETHSyncBlockQuartzJob : IJob
    {
        static ILog logger = LogManager.GetLogger("NETCoreRepository", typeof(ETHSyncBlockQuartzJob));

        public string ApiKey { get; set; }

        public string ApiUrl { get; set; }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var req = new ETHSyncBlockReq();

                req.Signature = req.SignByMD5(ApiKey);

                var http = WebRequest.CreateHttp($"{ApiUrl}{req.Service}");

                logger.Info($"{req.Service} requestText {req.ToJson()}");
                var responseText = http.PostJson(req.ToJson());
                logger.Info($"{req.Service} responseText {responseText}");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return null;
        }
    }
}
