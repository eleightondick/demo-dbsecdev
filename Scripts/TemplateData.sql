-- Cleanup Records
DELETE FROM dbo.People
DELETE FROM dbo.Companies
DELETE FROM dbo.Comments;

-- Insert Companies
INSERT INTO dbo.Companies
(
    Name
)
VALUES
(N'Water Nation' -- Name - nvarchar(max)
    )

INSERT INTO dbo.Companies
(
    Name
)
VALUES
(N'Air Nomads' -- Name - nvarchar(max)
    )

INSERT INTO dbo.Companies
(
    Name
)
VALUES
(N'Order of the White Lotus' -- Name - nvarchar(max)
    )

-- Insert People
INSERT INTO dbo.People
(
    FirstName,
    LastName,
    Company_Id
)
VALUES
(   N'General', -- FirstName - nvarchar(max)
    N'Iroh', -- LastName - nvarchar(max)
    (SELECT TOP 1 Id FROM dbo.Companies WHERE Name = 'Order of the White Lotus')    -- Company_Id - int
)

INSERT INTO dbo.People
(
    FirstName,
    LastName,
    Company_Id
)
VALUES
(   N'Avatar', -- FirstName - nvarchar(max)
    N'Aang', -- LastName - nvarchar(max)
    (SELECT TOP 1 Id FROM dbo.Companies WHERE Name = 'Air Nomads')    -- Company_Id - int
    )

INSERT INTO dbo.People
(
    FirstName,
    LastName,
    Company_Id
)
VALUES
(   N'Katara', -- FirstName - nvarchar(max)
    N'', -- LastName - nvarchar(max)
    (SELECT TOP 1 Id FROM dbo.Companies WHERE Name = 'Water Nation')    -- Company_Id - int
)