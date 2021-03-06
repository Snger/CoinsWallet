
DROP TABLE IF EXISTS ETH_TRANSACTIONDETAILS;

CREATE TABLE ETH_TRANSACTIONDETAILS
(
  ID BIGINT AUTO_INCREMENT PRIMARY KEY,
  TXID NVARCHAR(66) NOT NULL,
  ADDRESS NVARCHAR(66) NOT NULL,
  CATEGORY NVARCHAR(50) NOT NULL,
  AMOUNT DECIMAL(16, 8),
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=INNODB DEFAULT CHARSET=utf8;

ALTER TABLE ETH_TRANSACTIONDETAILS ADD INDEX IX_ETH_TRANSACTIONDETAILS_TXID(TXID);