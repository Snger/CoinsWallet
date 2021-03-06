
DROP TABLE IF EXISTS LTC_SENDREQUESTS;

CREATE TABLE LTC_SENDREQUESTS
(
  ID BIGINT AUTO_INCREMENT PRIMARY KEY,
  OUTREQUESTNO NVARCHAR(50) NOT NULL,
  ADDRESS NVARCHAR(64) NOT NULL,
  AMOUNT DECIMAL(16, 8),
  STATE INT DEFAULT 0,
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE LTC_SENDREQUESTS ADD UNIQUE UX_LTC_SENDREQUESTS_OUTREQUESTNO(OUTREQUESTNO);
ALTER TABLE LTC_SENDREQUESTS ADD INDEX IX_LTC_SENDREQUESTS_ADDRESS(ADDRESS);
ALTER TABLE LTC_SENDREQUESTS ADD INDEX IX_LTC_SENDREQUESTS_CREATETIME(CREATETIME);
ALTER TABLE LTC_SENDREQUESTS ADD INDEX IX_LTC_SENDREQUESTS_STATE(STATE);