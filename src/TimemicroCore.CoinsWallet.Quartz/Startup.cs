﻿using Microsoft.Extensions.Configuration;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using TimemicroCore.CoinsWallet.Quartz.Bitcoin;
using TimemicroCore.CoinsWallet.Quartz.BitcoinCash;
using TimemicroCore.CoinsWallet.Quartz.Litecoin;

namespace TimemicroCore.CoinsWallet.Quartz
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IScheduler scheduler;

        public async void Start()
        {
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            scheduler = await factory.GetScheduler();

            await scheduler.Start();

            if (Configuration.GetValue<bool>("CoinsWallet:BitcoinCash:Enabled"))
            {
                AddBCHConfirmTransactionQuartzJob();
                AddBCHReceiveNotifyQuartzJob();
                AddBCHSendNotifyQuartzJob();
                AddBCHSyncBlockQuartzJob();
                AddBCHSyncTransactionQuartzJob();
            }

            if (Configuration.GetValue<bool>("CoinsWallet:Bitcoin:Enabled"))
            {
                AddBTCConfirmTransactionQuartzJob();
                AddBTCReceiveNotifyQuartzJob();
                AddBTCSendNotifyQuartzJob();
                AddBTCSyncBlockQuartzJob();
                AddBTCSyncTransactionQuartzJob();
            }

            if (Configuration.GetValue<bool>("CoinsWallet:Zcash:Enabled"))
            {
                AddZECConfirmTransactionQuartzJob();
                AddZECReceiveNotifyQuartzJob();
                AddZECSendNotifyQuartzJob();
                AddZECSyncBlockQuartzJob();
                AddZECSyncTransactionQuartzJob();
            }

            if (Configuration.GetValue<bool>("CoinsWallet:Ethereum:Enabled"))
            {
                AddETHConfirmTransactionQuartzJob();
                AddETHReceiveNotifyQuartzJob();
                AddETHSendNotifyQuartzJob();
                AddETHSyncBlockQuartzJob();
                AddETHSyncTransactionQuartzJob();
            }

            if (Configuration.GetValue<bool>("CoinsWallet:Litecoin:Enabled"))
            {
                AddLTCConfirmTransactionQuartzJob();
                AddLTCReceiveNotifyQuartzJob();
                AddLTCSendNotifyQuartzJob();
                AddLTCSyncBlockQuartzJob();
                AddLTCSyncTransactionQuartzJob();
            }
        }

        public async void Stop()
        {
            if (scheduler != null)
            {
                await scheduler.Shutdown();
            }
        }

        #region BCH

        async void AddBCHConfirmTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BCHConfirmTransactionQuartzJob>()
                .WithIdentity("bchConfirmTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("bchConfirmTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBCHReceiveNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BCHReceiveNotifyQuartzJob>()
                .WithIdentity("bchReceiveNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("bchReceiveNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBCHSendNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BCHSendNotifyQuartzJob>()
                .WithIdentity("bchSendNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("bchSendNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBCHSyncBlockQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BCHSyncBlockQuartzJob>()
                .WithIdentity("bchSyncBlockQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("bchSyncBlockQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBCHSyncTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BCHSyncTransactionQuartzJob>()
                .WithIdentity("bchSyncTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("bchSyncTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        #endregion

        #region BTC

        async void AddBTCConfirmTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BTCConfirmTransactionQuartzJob>()
                .WithIdentity("btcConfirmTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("btcConfirmTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBTCReceiveNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BTCReceiveNotifyQuartzJob>()
                .WithIdentity("btcReceiveNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("btcReceiveNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBTCSendNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BTCSendNotifyQuartzJob>()
                .WithIdentity("btcSendNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("btcSendNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBTCSyncBlockQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BTCSyncBlockQuartzJob>()
                .WithIdentity("btcSyncBlockQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("btcSyncBlockQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddBTCSyncTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BTCSyncTransactionQuartzJob>()
                .WithIdentity("btcSyncTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("btcSyncTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        #endregion

        #region ZEC

        async void AddZECConfirmTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Zcash.ZECConfirmTransactionQuartzJob>()
                .WithIdentity("zecConfirmTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("zecConfirmTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddZECReceiveNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Zcash.ZECReceiveNotifyQuartzJob>()
                .WithIdentity("zecReceiveNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("zecReceiveNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddZECSendNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Zcash.ZECSendNotifyQuartzJob>()
                .WithIdentity("zecSendNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("zecSendNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddZECSyncBlockQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Zcash.ZECSyncBlockQuartzJob>()
                .WithIdentity("zecSyncBlockQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("zecSyncBlockQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddZECSyncTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Zcash.ZECSyncTransactionQuartzJob>()
                .WithIdentity("zecSyncTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("zecSyncTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        #endregion

        #region ETH

        async void AddETHConfirmTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Ethereum.ETHConfirmTransactionQuartzJob>()
                .WithIdentity("ethConfirmTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ethConfirmTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddETHReceiveNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Ethereum.ETHReceiveNotifyQuartzJob>()
                .WithIdentity("ethReceiveNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ethReceiveNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddETHSendNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Ethereum.ETHSendNotifyQuartzJob>()
                .WithIdentity("ethSendNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ethSendNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddETHSyncBlockQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Ethereum.ETHSyncBlockQuartzJob>()
                .WithIdentity("ethSyncBlockQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ethSyncBlockQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddETHSyncTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<Ethereum.ETHSyncTransactionQuartzJob>()
                .WithIdentity("ethSyncTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ethSyncTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        #endregion

        #region LTC

        async void AddLTCConfirmTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<LTCConfirmTransactionQuartzJob>()
                .WithIdentity("ltcConfirmTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ltcConfirmTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddLTCReceiveNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<LTCReceiveNotifyQuartzJob>()
                .WithIdentity("ltcReceiveNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ltcReceiveNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddLTCSendNotifyQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<BCHSendNotifyQuartzJob>()
                .WithIdentity("ltcSendNotifyQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ltcSendNotifyQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }


        async void AddLTCSyncBlockQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<LTCSyncBlockQuartzJob>()
                .WithIdentity("ltcSyncBlockQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ltcSyncBlockQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        async void AddLTCSyncTransactionQuartzJob()
        {
            IJobDetail job = JobBuilder.Create<LTCSyncTransactionQuartzJob>()
                .WithIdentity("ltcSyncTransactionQuartzJob", "group1")
                .UsingJobData("ApiKey", Configuration["coinswallet:apikey"])
                .UsingJobData("ApiUrl", Configuration["coinswallet:apiurl"])
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("ltcSyncTransactionQuartzJobTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        #endregion
    }
}
