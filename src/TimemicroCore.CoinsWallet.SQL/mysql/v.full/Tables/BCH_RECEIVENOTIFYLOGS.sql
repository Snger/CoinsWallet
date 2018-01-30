DROP TABLE IF EXISTS BCH_RECEIVENOTIFYLOGS;

CREATE TABLE BCH_RECEIVENOTIFYLOGS
(
  ID BIGINT AUTO_INCREMENT PRIMARY KEY,
  TXID NVARCHAR(64) NOT NULL,
  ADDRESS NVARCHAR(52),
  AMOUNT DECIMAL(16, 8) DEFAULT 0,
  NOTIFIEDCOUNT INT DEFAULT 0,
  NOTIFYRESPONSETEXT TEXT,
  NEXTNOTIFYTIME DATETIME  DEFAULT CURRENT_TIMESTAMP(),
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE BCH_RECEIVENOTIFYLOGS ADD INDEX IX_BCH_RECEIVENOTIFYLOGS_NEXTNOTIFYTIME(NEXTNOTIFYTIME);
