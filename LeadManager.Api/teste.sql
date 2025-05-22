USE LeadManagerDb;

INSERT INTO Leads (FirstName, FullName, Suburb, Category, Description, Price, Phone, Email, CreatedAt, Status)
VALUES 
('João', 'João Silva', 'Centro', 'Elétrica', 'Instalação de chuveiro', 300, '11999990001', 'joao@email.com', GETDATE(), 'invited'),
('Maria', 'Maria Souza', 'Jardins', 'Pintura', 'Pintura de sala', 800, '11999990002', 'maria@email.com', GETDATE(), 'invited'),
('Carlos', 'Carlos Oliveira', 'Moema', 'Pedreiro', 'Reforma de banheiro', 1200, '11999990003', 'carlos@email.com', GETDATE(), 'accepted');
