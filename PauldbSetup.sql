-- Active: 1760459935767@@mysql.codeworksacademy.com@3306@intuitive_elephant_ef9f_db
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
) DEFAULT charset utf8mb4 COMMENT '';

CREATE TABLE houses (
    id INT PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    price MEDIUMINT UNSIGNED NOT NULL,
    img_url VARCHAR(500) NOT NULL,
    bedrooms TINYINT UNSIGNED NOT NULL,
    bathrooms TINYINT UNSIGNED NOT NULL,
    stories TINYINT UNSIGNED NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    Foreign Key (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
)

DROP TABLE houses;

DROP TABLE accounts;

INSERT INTO
    houses (
        price,
        img_url,
        bedrooms,
        bathrooms,
        stories,
        creator_id
    )
VALUES (
        675000,
        'https://images.unsplash.com/photo-1760472915957-43c64f62adeb?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=687',
        5,
        3,
        3,
        '68f0074866de1bae805da438'
    ),
    (
        475000,
        'https://images.unsplash.com/photo-1760472915957-43c64f62adeb?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=687',
        6,
        4,
        1,
        '68f007cfb3779423b1c0387a'
    )

SELECT * FROM houses

SELECT * FROM houses WHERE id = 1

SELECT * FROM accounts