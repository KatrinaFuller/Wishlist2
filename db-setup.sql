-- USE wishlisr1;

-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     hash VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

-- CREATE TABLE lists (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE wishes (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     views INT DEFAULT 0,
--     shares INT DEFAULT 0,
--     wishes INT DEFAULT 0,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE listwishes (
--     id int NOT NULL AUTO_INCREMENT,
--     listId int NOT NULL,
--     wishId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (listId, wishId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (listId)
--         REFERENCES lists(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (wishId)
--         REFERENCES wishes(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET WISHES BY LISTID
-- SELECT * FROM listwishes lw
-- INNER JOIN wishes w ON w.id = lw.wishId 
-- WHERE (listId = @listId AND lw.userId = @userId) 



-- -- USE THIS TO CLEAN OUT YOUR DATABASE
-- DROP TABLE IF EXISTS listwishes;
-- DROP TABLE IF EXISTS lists;
-- DROP TABLE IF EXISTS wishes;
-- DROP TABLE IF EXISTS users;
