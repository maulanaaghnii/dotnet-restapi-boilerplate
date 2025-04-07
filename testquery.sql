-- Insert Users
INSERT INTO tbluserprofile (uuid, username, email, first_name, last_name, description, birth_date, created_at, is_deleted)
VALUES 
(UUID(), 'johndoe', 'john@example.com', 'John', 'Doe', 'Software Developer', '1990-01-01', NOW(), 0),
(UUID(), 'janedoe', 'jane@example.com', 'Jane', 'Doe', 'UI/UX Designer', '1992-05-15', NOW(), 0);

-- Get the UUIDs of inserted users
SET @john_uuid = (SELECT uuid FROM tbluserprofile WHERE email = 'john@example.com');
SET @jane_uuid = (SELECT uuid FROM tbluserprofile WHERE email = 'jane@example.com');

-- Insert Blog Posts
INSERT INTO tblblogpost (uuid, title, content, author_id, status, created_at, updated_at, is_deleted)
VALUES 
(UUID(), 'Getting Started with .NET Core', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', @john_uuid, 'published', NOW(), NOW(), 0),
(UUID(), 'Best Practices in API Design', 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', @john_uuid, 'published', NOW(), NOW(), 0),
(UUID(), 'UI/UX Principles', 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.', @jane_uuid, 'draft', NOW(), NOW(), 0);

-- Test Queries
SELECT 'User List' as 'Query 1';
SELECT username, email, first_name, last_name FROM tbluserprofile WHERE is_deleted = 0;

SELECT 'Blog Posts with Authors' as 'Query 2';
SELECT 
    b.title,
    b.status,
    b.created_at,
    u.username as author_username,
    u.email as author_email
FROM tblblogpost b
JOIN tbluserprofile u ON b.author_id = u.uuid
WHERE b.is_deleted = 0
ORDER BY b.created_at DESC;
