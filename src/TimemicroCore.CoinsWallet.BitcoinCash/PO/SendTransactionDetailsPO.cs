﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimemicroCore.CoinsWallet.BitcoinCash.PO
{
    public class SendTransactionDetailsPO
    {
        public SendTransactionPO SendTransaction { get; set; }

        public string Address { get; set; }

        public decimal Amount { get; set; }
    }
}
