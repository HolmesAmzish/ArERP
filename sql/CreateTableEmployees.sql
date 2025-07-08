IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
BEGIN
    CREATE TABLE Employees (
        EmployeeId INT IDENTITY(1,1) PRIMARY KEY,        -- Ա��ID������������
        EmployeeName NVARCHAR(100) NOT NULL,             -- Ա������
        Gender NVARCHAR(10),                             -- �Ա�
        BirthDate DATE,                                  -- ��������
        Email NVARCHAR(255),                             -- ����
        Phone NVARCHAR(50),                              -- �绰
        HireDate DATE DEFAULT GETDATE(),                 -- ��ְ���ڣ�Ĭ�ϵ�ǰ����
        Department NVARCHAR(100),                        -- ����
        Position NVARCHAR(100),                          -- ְλ
        Salary DECIMAL(18,2),                            -- нˮ
        IsActive BIT DEFAULT 1                           -- �Ƿ���ְ��1=��ְ��0=��ְ��
    );
END