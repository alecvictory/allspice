-- CREATE TABLE
--  CREATE TABLE accounts (
--    id VARCHAR(255) NOT NULL,
--    name VARCHAR(255) NOT NULL,
--    email VARCHAR(255) NOT NULL,
--    picture VARCHAR(255) NOT NULL,
--    PRIMARY KEY (id)
-- );

-- DROP TABLE recipes

--  CREATE TABLE recipes(
-- id INT AUTO_INCREMENT NOT NULL,
-- creatorId VARCHAR(255) NOT NULL,
-- name VARCHAR(255) NOT NULL,
-- description VARCHAR (255) NOT NULL,
-- cooktime INT NOT NULL, 
-- picture VARCHAR (255) NOT NULL,
-- PRIMARY KEY(id),

-- FOREIGN KEY (creatorId)
--     REFERENCES accounts (id)
--     ON DELETE CASCADE
-- )

-- SELECT * FROM recipes

-- INSERT INTO recipes
--             (name, description, cooktime)
--             VALUES
--             ("carbonara", "delicious pasta", 20)

-- CREATE TABLE ingredients(
-- id INT AUTO_INCREMENT NOT NULL,
-- recipeId INT AUTO_INCREMENT NOT NULL,
-- name VARCHAR(255) NOT NULL,
-- quantity VARCHAR(255) NOT NULL,
-- description VARCHAR (255) NOT NULL,

-- PRIMARY KEY(id),

-- FOREIGN KEY (recipeId)
--     REFERENCES recipes (id)
--     ON DELETE CASCADE
-- )