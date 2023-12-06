CREATE TABLE IF NOT EXISTS "user" (
	"id" TEXT NOT NULL,
    "username" TEXT NOT NULL,
    "password" TEXT NOT NULL,

    PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS book (
  "id" TEXT NOT NULL,
  "isbn" TEXT NOT NULL,
  "title" TEXT NOT NULL,
  "publish_date" DATE NOT NULL,
  "language" TEXT NOT NULL,  

  PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS author (
  "id" TEXT NOT NULL,
  "first_name" TEXT NOT NULL,
  "last_date" TEXT NOT NULL,  

  PRIMARY KEY ("id")
);

CREATE TABLE IF NOT EXISTS book_author (
  "author_id" TEXT NOT NULL,
  "book_id" TEXT NOT NULL,

  PRIMARY KEY ("author_id", "book_id")
);
