IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
    CREATE TABLE Employees (
        EmployeeId INT IDENTITY(1,1) PRIMARY KEY,        -- 员工ID，自增长主键
        EmployeeName NVARCHAR(100) NOT NULL,             -- 员工姓名
        Gender NVARCHAR(10),                             -- 性别
        BirthDate DATE,                                  -- 出生日期
        Email NVARCHAR(255),                             -- 邮箱
        Phone NVARCHAR(50),                              -- 电话
        HireDate DATE DEFAULT GETDATE(),                 -- 入职日期，默认当前日期
        Department NVARCHAR(100),                        -- 部门
        Position NVARCHAR(100),                          -- 职位
        Salary DECIMAL(18,2),                            -- 薪水
        IsActive BIT DEFAULT 1                           -- 是否在职（1=在职，0=离职）
    );
END