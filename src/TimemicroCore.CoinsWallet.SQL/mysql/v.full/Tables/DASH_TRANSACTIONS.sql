DROP TABLE IF EXISTS DASH_TRANSACTIONS;

CREATE TABLE DASH_TRANSACTIONS
(
  TXID NVARCHAR(64) PRIMARY KEY NOT NULL,
  BLOCKHASH NVARCHAR(64) NOT NULL,
  CONFIRMATIONS INT DEFAULT 0,
  STATE INT DEFAULT 0,
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE DASH_TRANSACTIONS ADD INDEX IX_DASH_TRANSACTIONS_BLOCKHASH(BLOCKHASH);
ALTER TABLE DASH_TRANSACTIONS ADD INDEX IX_DASH_TRANSACTIONS_STATE(STATE);