﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimemicroCore.CoinsWallet.Sdk.Litecoin
{
    public class LTCSyncTransactionResp : CoinsWalletApiRespData
    {
        public LTCSyncTransactionResp()
        {
            Service = "ltc_synctransaction";
        }
    }
}
