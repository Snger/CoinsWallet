
DROP TABLE IF EXISTS BCH_SENDREQUESTS;

CREATE TABLE BCH_SENDREQUESTS
(
  ID BIGINT AUTO_INCREMENT PRIMARY KEY,
  OUTREQUESTNO NVARCHAR(50) NOT NULL,
  ADDRESS NVARCHAR(64) NOT NULL,
  AMOUNT DECIMAL(16, 8),
  STATE INT DEFAULT 0,
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE BCH_SENDREQUESTS ADD UNIQUE UX_BCH_SENDREQUESTS_OUTREQUESTNO(OUTREQUESTNO);
ALTER TABLE BCH_SENDREQUESTS ADD INDEX IX_BCH_SENDREQUESTS_ADDRESS(ADDRESS);
ALTER TABLE BCH_SENDREQUESTS ADD INDEX IX_BCH_SENDREQUESTS_CREATETIME(CREATETIME);
ALTER TABLE BCH_SENDREQUESTS ADD INDEX IX_BCH_SENDREQUESTS_STATE(STATE);