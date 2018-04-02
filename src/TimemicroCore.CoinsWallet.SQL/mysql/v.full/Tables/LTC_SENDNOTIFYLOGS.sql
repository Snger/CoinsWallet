DROP TABLE IF EXISTS LTC_SENDNOTIFYLOGS;

CREATE TABLE LTC_SENDNOTIFYLOGS
(
  ID BIGINT AUTO_INCREMENT PRIMARY KEY,
  OUTREQUESTNO NVARCHAR(50) NOT NULL,
  TXID NVARCHAR(64) NOT NULL,
  ADDRESS NVARCHAR(34),
  NOTIFIEDCOUNT INT DEFAULT 0,
  NOTIFYRESPONSETEXT TEXT,
  NEXTNOTIFYTIME DATETIME  DEFAULT CURRENT_TIMESTAMP(),
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE LTC_SENDNOTIFYLOGS ADD INDEX IX_LTC_SENDNOTIFYLOGS_NEXTNOTIFYTIME(NEXTNOTIFYTIME);
