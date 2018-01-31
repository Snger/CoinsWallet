DROP TABLE IF EXISTS BCH_BLOCKS;

CREATE TABLE BCH_BLOCKS
(
  HASH NVARCHAR(64) PRIMARY KEY NOT NULL,
  HEIGHT INT,
  STATE INT,
  CREATETIME DATETIME DEFAULT CURRENT_TIMESTAMP()
)ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE BCH_BLOCKS ADD UNIQUE UX_BCH_BLOCKS_HEIGHT(HEIGHT);