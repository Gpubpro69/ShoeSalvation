Shoe Ecommerce API
Project Overview
A prototype RESTful Web API for a shoe ecommerce platform built with ASP.NET Core. The system handles product catalog management, user authentication, cart, wishlist, orders, and returns. It is designed as a reusable template and follows a layered architecture with full SDLC documentation.


Actors & Roles
Role
Description
Admin
Manages products, stock, brands, categories, and prices
Customer
Registered user who can browse, cart, wishlist, and order
Guest
Unauthenticated user — browse and view only

Functional Requirements
Admin can:
Add, edit, and delete shoe products and variants
Manage stock quantity via stock adjustments
Manage brands, categories, and subcategories
View price history per variant
Customer can:
Register and login
Browse, search, and filter shoes by category/subcategory/brand
View product and variant details
Add/remove items from cart (quantity adjusted if same variant)
Add/remove items from wishlist
Place an order with a delivery address
Request a return on a delivered order
Guest can:
Browse, search, and filter shoes
View product details
Cannot access cart, wishlist, or orders without logging in

Tech Stack
Concern
Technology
Framework
ASP.NET Core 8 Web API
ORM
Entity Framework Core
Database
SQL Server
Authentication
JWT + Refresh Tokens
Containerization
Docker + Docker Compose
Version Control
Git + GitHub

Entity Model
User & Auth
User RefreshToken
────────────────────── ──────────────────────
id id
firstName userId (FK → User)
lastName token
email (unique) expiresAt
passwordHash isRevoked
role (Admin, Customer) createdAt
isActive
createdAt / updatedAt

Address
──────────────────────
id
userId (FK → User)
fullName / phone
street / city / state
zipCode / country
isDefault

Catalog
Brand Category SubCategory
───────────── ───────────── ─────────────────────
id id id
name name name
logoUrl categoryId (FK → Category)
createdAt

Product
──────────────────────────────────────────
id
name / description
brandId (FK → Brand)
categoryId (FK → Category)
subcategoryId (FK → SubCategory)
primaryImageUrl
isActive
createdAt / updatedAt

ProductVariant PriceHistory
────────────────────── ──────────────────────────
id id
productId (FK → Product) variantId (FK → Variant)
color / size oldMrp / newMrp
mrp / sellingPrice oldSellingPrice / newSellingPrice
stockQuantity (>= 0) changedAt
imageUrl changedBy (FK → User)
isActive
createdAt / updatedAt

Cart & Wishlist
Cart CartItem
────────────────────── ──────────────────────────
id id
userId (FK → User, unique) cartId (FK → Cart)
createdAt / updatedAt variantId (FK → Variant)
quantity (>= 1)
addedAt

Wishlist WishlistItem
────────────────────── ──────────────────────────
id id
userId (FK → User, unique) wishlistId (FK → Wishlist)
createdAt variantId (FK → Variant)
addedAt

Orders & Returns
Order OrderItem
────────────────────────── ──────────────────────────────
id id
userId (FK → User) orderId (FK → Order)
addressId (FK → Address) variantId (FK → Variant)
status quantity
(Pending, Confirmed, priceAtPurchase ← snapshot
Shipped, Delivered, mrpAtPurchase ← snapshot
Returned)
paymentStatus
(Pending, Paid, Refunded)
paymentReference (mocked)
totalAmount
createdAt / updatedAt

Return StockAdjustment
────────────────────────── ──────────────────────────────
id id
orderId (FK → Order) variantId (FK → Variant)
userId (FK → User) adjustmentType
reason (Restock, ReturnRestock,
status Correction)
(Requested, Approved, quantity (can be negative)
Rejected, Completed) note
createdAt / updatedAt adjustedBy (FK → User)
adjustedAt


Key Design Decisions
1. Product Variant Pattern
A shoe product is split into a base Product and multiple ProductVariant records. Each variant represents a unique Color + Size combination with its own stock and price.

Nike Air Max Black Size 40 ≠ Nike Air Max Red Size 40
2. Price Snapshot on OrderItem
OrderItem stores priceAtPurchase and mrpAtPurchase at the time of order. This ensures order history is never affected by future price changes on the variant.

3. JWT + Refresh Token Auth
Stateless JWT is used for simplicity. A RefreshToken table allows token invalidation without full session tracking — balancing simplicity with security.

4. Stock Cannot Go Negative
Enforced at the service layer, not just the database. StockAdjustment tracks every change to stock with a reason and responsible user.


Out of Scope (Prototype)
Coupon / promo code system
Real payment gateway (payment is mocked)
Multiple wishlists per user
Product reviews and ratings
Email notifications

Collaboration Guide
Prerequisites
Docker Desktop installed
Git installed
Running the Project
git clone <repo-url>
cd shoe-ecommerce-api
docker compose up

API will be available at http://localhost:5000

Branch Strategy
main ← stable only, no direct pushes
dev ← active development
feature/* ← individual features branched from dev

Who Owns What
Layer
Owner
Docker, EF Core, Auth setup
Lead Dev
Business logic, Services
Collaborator
Controllers, DTOs
Shared
Tests
Shared
