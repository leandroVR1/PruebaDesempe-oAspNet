-- Active: 1717616890381@@bvdostxwwxivo4mckf5x-mysql.services.clever-cloud.com@3306@bvdostxwwxivo4mckf5x

CREATE TABLE students (
    Id INT  PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125),
    BirthDate DATE,
    Address VARCHAR(125),
    Email VARCHAR(125)
)

INSERT INTO students (Names, BirthDate, Address, Email)VALUES
 ('John', '2001-09-12', 'calle1','John@gmail.com'),
 ('Jane', '2002-08-24', 'calle2','Jane@gmail.com'),
 ('Mary', '2004-01-22', 'calle3','Mary@gmail.com')


CREATE TABLE teachers (
    Id INT  PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125),
    Speciality VARCHAR(125),
    Phone VARCHAR(125),
    Email VARCHAR(125),
    YearsExperience INT
)

 INSERT INTO teachers (Names, Speciality, Phone, Email, YearsExperience)VALUES
 ('Luis', 'Math', '123456789', 'Luis@gmail.com','3'),
 ('Maria', 'Biology', '987654321', 'Maria@gamil.com' , '2'),
 ('Pedro', 'Chemistry', '246813579', 'Pedro@gmail.com','5')


CREATE TABLE courses (
    Id INT  PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125),
    Description TEXT,
    Schedule VARCHAR(125),
    Duration VARCHAR(125),
    TeacherId INT,
    FOREIGN KEY (TeacherId) REFERENCES teachers(Id)
)


INSERT INTO courses (Name, Description, Schedule, Duration, TeacherId)VALUES
('Math', 'Pythagoras theorem', 'Monday', '2 hours', '1'),
('Biology', 'study of the human body', 'Tuesday', '3 hours', '2'),
('Chemistry', 'study of the elements', 'Wednesday', '4 hours', '3')


CREATE TABLE enrollments(
    Id INT  PRIMARY KEY AUTO_INCREMENT,
    Date DATE,
    StudentId INT,
    CourseId INT,
    FOREIGN KEY (StudentId) REFERENCES students(Id),
    FOREIGN KEY (CourseId) REFERENCES courses(Id)
)

INSERT INTO enrollments (Date, StudentId, CourseId,Status) VALUES
()

ALTER TABLE enrollments ADD Status ENUM ('pagada','pendiente','cancelada')