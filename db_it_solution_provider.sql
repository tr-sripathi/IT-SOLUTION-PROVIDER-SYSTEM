CREATE DATABASE IF NOT EXISTS db_it_solution_provider;
USE db_it_solution_provider;

DROP TABLE IF EXISTS tbl_issue_detail;
CREATE TABLE IF NOT EXISTS tbl_issue_detail (
  ID int(11) NOT NULL AUTO_INCREMENT,
  Issue_Category varchar(100) DEFAULT NULL,
  Issue_Date date DEFAULT NULL,
  Priority varchar(100) DEFAULT NULL,
  Status varchar(100) DEFAULT NULL,
  Solution varchar(300) DEFAULT NULL,
  Engin_Id int(11) DEFAULT NULL,
  Feedback varchar(300) DEFAULT NULL,
  Description varchar(300) DEFAULT NULL,
  UserId int(11) DEFAULT NULL,
  PRIMARY KEY (ID)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;


INSERT INTO tbl_issue_detail (ID, Issue_Category, Issue_Date, Priority, Status, Solution, Engin_Id, Feedback, Description, UserId) VALUES
(2, 'Hardware', '2023-04-16', 'High', 'Cancel', NULL, NULL, 'Sorry', 'Mouse Not Working', 1),
(4, 'Hardware', '2023-04-16', 'High', 'Resolved', 'Change Key Board', 1, 'Thanks', 'Key board n key not working', 2),
(5, 'Hardware', '2023-04-26', 'High', 'Resolved', NULL, 3, 'Good Service', 'Mouse Not Working', 1),
(6, 'Hardware', '2023-04-27', 'High', 'Resolved', 'Resolved', 3, 'Good', 'Keyboard Issue', 1),
(11, 'Software', '2023-04-11', 'Low', 'Cancel', NULL, NULL, 'Cancelled', 'browser stuck', 1),
(12, 'Hardware', '2023-04-12', 'High', 'Resolved', 'Okay, It changed', 3, 'Nice service.', 'Charger broken', 1);

DROP TABLE IF EXISTS tbl_user_registration;
CREATE TABLE IF NOT EXISTS tbl_user_registration (
  UserID int(11) NOT NULL AUTO_INCREMENT,
  UserName varchar(100) DEFAULT NULL,
  FirstName varchar(100) DEFAULT NULL,
  LastName varchar(100) DEFAULT NULL,
  Email varchar(200) DEFAULT NULL,
  PhoneNO varchar(100) DEFAULT NULL,
  Password varchar(100) DEFAULT NULL,
  UserRoles varchar(100) DEFAULT NULL,
  PRIMARY KEY (UserID)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;


INSERT INTO tbl_user_registration (UserID, UserName, FirstName, LastName, Email, PhoneNO, Password, UserRoles) VALUES
(1, 'teja', 'Teja', 'Sripathi', 'teja@gmail.com', '8767675656', 'teja', 'Customers'),
(3, 'dinesh', 'Dinesh', 'Merugu', 'dinesh@gmail.com', '8007675656', 'dinesh', 'Engineers');
COMMIT;