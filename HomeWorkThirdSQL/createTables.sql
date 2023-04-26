CREATE TABLE Groups (
   gr_id INT NOT NULL PRIMARY KEY,
   gr_name VARCHAR(50) NOT NULL,
   gr_temp INT NOT NULL
);

GO
CREATE TABLE Analysis (
   an_id INT NOT NULL PRIMARY KEY,
   an_name VARCHAR(50) NOT NULL,
   an_cost DECIMAL(10,2) NOT NULL,
   an_price DECIMAL(10,2) NOT NULL,
   an_group INT NOT NULL REFERENCES Groups(gr_id)
);

GO
CREATE TABLE Orders (
   ord_id INT NOT NULL PRIMARY KEY,
   ord_datetime DATETIME NOT NULL,
   ord_an INT NOT NULL REFERENCES Analysis(an_id)
);