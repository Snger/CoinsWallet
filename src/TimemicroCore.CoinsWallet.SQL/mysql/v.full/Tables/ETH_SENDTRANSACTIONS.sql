
DROP TABLE IF EXISTS ETH_SENDTRANSACTIONS;

CREATE TABLE ETH_SENDTRANSACTIONS
(
  TXID NVARCHAR(66) PRIMARY KEY,
  AMOUNT DECIMAL(16, 8),
  FEE DECIMAL(16, 8),
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;