## ✅ Altyapı Kurulumu

* .NET 8 + React + Vite fullstack proje kuruldu
* Docker ile Redis ve RabbitMQ hazırlandı
* Projeler: `BankApp.Api`, `Application`, `Domain`, `Infrastructure`

---

## ✅ Veritabanı ve ORM

* ❌ InMemory DB (ilk versiyon – kaldırıldı)
* ✅ **SQLite** kullanılıyor (EF Core + Dapper birlikte)
* `AppDbContext` SQLite bağlantısıyla yapılandırıldı
* `bank.db` dosyası uygulama dizinine yazılıyor

---

## ✅ Entity & Seed

* `Transaction` entity’si tanımlandı (AccountId, Amount, Type, CreatedAt, Description, User, UserId)
* `User` entity’si tanımlandı (FirstName, LastName, Email, CreatedAt, Transactions, FullName)
* Uygulama başlatıldığında otomatik **seed data** ekleniyor

---

## ✅ CQRS + MediatR

* ✔ `CreateTransactionCommand` → EF Core ile write
* ✔ `GetAllTransactionsQuery` → **Dapper** ile read (DTO)
* ✔ `CreateUserCommand` → EF Core ile write
* ✔ `GetAllUsersQuery` → **Dapper** ile read (DTO)
* ✔ Handler’lar Application katmanında tanımlandı

---

## ✅ API

* `POST /api/transactions` → yeni işlem ekler
* `GET /api/transactions` → işlemleri listeler (Dapper ile performanslı)
* `POST /api/users` → yeni kullanıcı ekler
* `GET /api/users` → kullanıcıları listeler (Dapper ile performanslı)

---

## ✅ Frontend

* React + TypeScript (Vite tabanlı)
* `TransactionList.tsx` ile listeleme yapılıyor
* Axios ile backend’e istek atılıyor
* UI dinamik, veri güncellemelerini otomatik gösteriyor

---

## ✅ Ek Özellikler

* CORS (`http://localhost:5173`) açıldı
* SQLite + Dapper aynı anda kullanılıyor
* `curl` ve React ile testler yapıldı, başarılı sonuç alındı