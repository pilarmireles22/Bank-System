INSERT INTO "Clients"(
            "ClientID", "Name", "Email")
    VALUES (1, 'Pilar', 'pilar.2m@hotmail.com');

INSERT INTO "Clients"(
            "ClientID", "Name", "Email")
    VALUES (2, 'Keisy', 'keisyperezav@gmail.com');
	
	INSERT INTO "Banks"(
            "BankID", "Name", "Address")
    VALUES (1, 'BHD', 'Maximo gomez');

INSERT INTO "Accounts"(
            "AccountID", "AccountNumber", "Balance", "Bank_BankID", "Client_ClientID")
    VALUES (1, 12345, 20.2, 1, 1);

INSERT INTO "Accounts"(
            "AccountID", "AccountNumber", "Balance", "Bank_BankID", "Client_ClientID")
    VALUES (2, 123456, 30.2, 1, 2);