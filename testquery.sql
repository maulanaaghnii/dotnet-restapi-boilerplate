-- Insert Users
INSERT INTO tbluserprofile (uuid, username, email, first_name, last_name, description, birth_date, created_at, is_deleted)
VALUES 
('550e8400-e29b-41d4-a716-446655440000', 'admin', 'admin@example.com', 'Admin', 'System', 'System Administrator', '1990-01-01', NOW(), 0),
('550e8400-e29b-41d4-a716-446655440001', 'manager', 'manager@example.com', 'Project', 'Manager', 'Project Manager', '1992-05-15', NOW(), 0),
('550e8400-e29b-41d4-a716-446655440002', 'developer', 'dev@example.com', 'Software', 'Developer', 'Backend Developer', '1995-08-20', NOW(), 0);

-- Get the UUIDs of inserted users
SET @admin_uuid = (SELECT uuid FROM tbluserprofile WHERE email = 'admin@example.com');
SET @manager_uuid = (SELECT uuid FROM tbluserprofile WHERE email = 'manager@example.com');
SET @developer_uuid = (SELECT uuid FROM tbluserprofile WHERE email = 'dev@example.com');

-- Insert Products
INSERT INTO tblproduct (uuid, sku, name, description, price, stock, category, status, created_at, updated_at, is_deleted)
VALUES 
('770e8400-e29b-41d4-a716-446655440000', 'LPX001', 'Laptop Pro X1', 'Laptop untuk professional developer', 15000000.00, 10, 'Laptop', 'active', NOW(), NOW(), 0),
('770e8400-e29b-41d4-a716-446655440001', 'MNT001', 'Monitor 4K', 'Monitor resolusi tinggi 32 inch', 5000000.00, 15, 'Monitor', 'active', NOW(), NOW(), 0),
('770e8400-e29b-41d4-a716-446655440002', 'KBD001', 'Mechanical Keyboard', 'Keyboard gaming mechanical switch', 1200000.00, 25, 'Peripheral', 'active', NOW(), NOW(), 0),
('770e8400-e29b-41d4-a716-446655440003', 'MOU001', 'Mouse Gaming', 'Mouse gaming wireless', 800000.00, 30, 'Peripheral', 'active', NOW(), NOW(), 0);

-- Insert Blog Posts
INSERT INTO tblblogpost (uuid, title, content, author_id, status, created_at, updated_at, is_deleted)
VALUES 
('660e8400-e29b-41d4-a716-446655440000', 'Panduan REST API dengan .NET Core', 'Artikel ini akan membahas cara membuat REST API menggunakan .NET Core dengan best practices.', '550e8400-e29b-41d4-a716-446655440000', 'published', NOW(), NOW(), 0),
('660e8400-e29b-41d4-a716-446655440001', 'Implementasi JWT Authentication', 'Tutorial lengkap implementasi JWT Authentication di .NET Core API.', '550e8400-e29b-41d4-a716-446655440002', 'published', NOW(), NOW(), 0),
('660e8400-e29b-41d4-a716-446655440002', 'Project Management Tips', 'Tips dan trik dalam mengelola proyek pengembangan software.', '550e8400-e29b-41d4-a716-446655440001', 'draft', NOW(), NOW(), 0);

-- Test Queries
SELECT 'Daftar Pengguna' as 'Query 1';
SELECT uuid, username, email, first_name, last_name, description, birth_date, created_at 
FROM tbluserprofile 
WHERE is_deleted = 0;

SELECT 'Daftar Produk' as 'Query 2';
SELECT 
    uuid,
    sku,
    name,
    description,
    price,
    stock,
    category,
    status,
    created_at,
    updated_at
FROM tblproduct 
WHERE is_deleted = 0
ORDER BY created_at DESC;

SELECT 'Artikel Blog dengan Penulis' as 'Query 3';
SELECT 
    b.uuid,
    b.title,
    b.content,
    b.status,
    b.created_at,
    b.updated_at,
    b.published_at,
    u.username as author_username,
    u.first_name as author_first_name,
    u.last_name as author_last_name
FROM tblblogpost b
JOIN tbluserprofile u ON b.author_id = u.uuid
WHERE b.is_deleted = 0
ORDER BY b.created_at DESC;
