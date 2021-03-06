﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimemicroCore.CoinsWallet.BitcoinCash.PO
{
    public class ReceiveNotifyLogPO
    {
        public long Id { get; set; }

        public string TxId { get; set; }

        public string Address { get; set; }

        public decimal Amount { get; set; }

        public int NotifiedCount { get; set; }

        public string NotifyResponseText { get; set; }

        public DateTime NextNotifyTime { get; set; }
    }
}
