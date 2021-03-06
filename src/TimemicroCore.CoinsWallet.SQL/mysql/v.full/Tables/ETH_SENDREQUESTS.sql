
DROP TABLE IF EXISTS ETH_SENDREQUESTS;

CREATE TABLE ETH_SENDREQUESTS
(
  ID BIGINT AUTO_INCREMENT PRIMARY KEY,
  OUTREQUESTNO NVARCHAR(50) NOT NULL,
  ADDRESS NVARCHAR(66) NOT NULL,
  AMOUNT DECIMAL(16, 8),
  STATE INT DEFAULT 0,
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=INNODB DEFAULT CHARSET=utf8;

ALTER TABLE ETH_SENDREQUESTS ADD UNIQUE UX_ETH_SENDREQUESTS_OUTREQUESTNO(OUTREQUESTNO);
ALTER TABLE ETH_SENDREQUESTS ADD INDEX IX_ETH_SENDREQUESTS_ADDRESS(ADDRESS);
ALTER TABLE ETH_SENDREQUESTS ADD INDEX IX_ETH_SENDREQUESTS_CREATETIME(CREATETIME);
ALTER TABLE ETH_SENDREQUESTS ADD INDEX IX_ETH_SENDREQUESTS_STATE(STATE);