DROP TABLE IF EXISTS AUTH;
CREATE TABLE AUTH (
    `AUTHID` BIGINT NOT NULL AUTO_INCREMENT,
    `NAME` TEXT NOT NULL,
    `PWD` LONGTEXT NOT NULL,
    `EMAIL` TEXT NOT NULL,

    PRIMARY KEY(`AUTHID`)
);