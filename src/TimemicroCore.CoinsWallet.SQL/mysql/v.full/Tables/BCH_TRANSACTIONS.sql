DROP TABLE IF EXISTS BCH_TRANSACTIONS;

CREATE TABLE BCH_TRANSACTIONS
(
  TXID NVARCHAR(64) PRIMARY KEY NOT NULL,
  BLOCKHASH NVARCHAR(64) NOT NULL,
  CONFIRMATIONS INT DEFAULT 0,
  STATE INT DEFAULT 0,
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE BCH_TRANSACTIONS ADD INDEX IX_BCH_TRANSACTIONS_BLOCKHASH(BLOCKHASH);
ALTER TABLE BCH_TRANSACTIONS ADD INDEX IX_BCH_TRANSACTIONS_STATE(STATE);