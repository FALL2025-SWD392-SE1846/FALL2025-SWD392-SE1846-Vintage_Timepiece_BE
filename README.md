# 🕰️ Vintage Timepiece Marketplace Platform

A comprehensive platform for buying, selling, and authenticating vintage watches. The system streamlines the process for sellers to submit watches for appraisal, receive offers, and complete transactions, while ensuring secure payments for both parties.

---

## 📋 Mục lục / Table of Contents
- 🎯 Giới thiệu / Overview
- 👥 Đối tượng sử dụng / Target Users & Roles
- ✨ Tính năng chính / Key Features
- 🛠 Công nghệ sử dụng / Technology Stack
- 🚀 Cài đặt / Installation
- 📱 Sử dụng / Usage
- 🤝 Đóng góp / Contributing
- 📄 Giấy phép / License
- 📞 Hỗ trợ / Support

---

## 🎯 Giới thiệu / Overview

**Vintage Timepiece Marketplace** là nền tảng quản lý toàn diện quy trình mua, bán và thẩm định đồng hồ. Người bán có thể gửi đồng hồ để thẩm định, nhận kết quả và quyết định bán với mức giá đề xuất hoặc nhận lại đồng hồ. Mọi giao dịch và xác thực được thực hiện minh bạch, bảo vệ quyền lợi cả hai bên.

A full-featured web application for vintage watch trading: submit watches for appraisal, receive timely notifications, sell directly if agreed with the price, and ensure secure payment and delivery.

---

## 👥 Đối tượng sử dụng / Target Users & Roles

| Vai trò        | Mô tả                                         | Quyền hạn                                                |
|----------------|-----------------------------------------------|----------------------------------------------------------|
| 🧑‍💼 Seller    | Cá nhân bán đồng hồ vintage                   | Gửi đồng hồ thẩm định, nhận thông báo, quyết định bán    |
| 🏢 Company     | Đơn vị vận hành & thẩm định đồng hồ           | Nhận đồng hồ, thẩm định, gửi kết quả, quản lý giao dịch  |
| 🛒 Buyer       | Người muốn mua đồng hồ trên nền tảng          | Tìm kiếm, đặt mua, thanh toán                            |
| 👩‍💻 Admin      | Quản trị hệ thống                             | Quản lý sản phẩm, giao dịch, người dùng, báo cáo         |

---

## ✨ Tính năng chính / Key Features

### 🔹 Người bán (Seller)
- Đăng ký gửi đồng hồ thẩm định online
- Nhận thông báo khi công ty nhận đồng hồ
- Nhận kết quả thẩm định trong 2-3 ngày làm việc:
    - **Đồng ý giá:** Hoàn tất quy trình bán, đồng hồ niêm yết trên web
    - **Không đồng ý:** Thanh toán phí thẩm định, trả lại đồng hồ & giấy tờ
- Đăng ký bán với giấy thẩm định hợp lệ (trong 6 tháng)
- Theo dõi trạng thái đồng hồ, lịch sử giao dịch

### 🔹 Công ty (Company/Appraiser)
- Quản lý tiếp nhận đồng hồ gửi thẩm định
- Thực hiện thẩm định, cập nhật trạng thái, gửi kết quả cho người bán
- Quản lý phí thẩm định & xử lý các trường hợp không đồng ý giá
- Đăng bán đồng hồ đã thẩm định hợp lệ
- Quản lý giao dịch, xác nhận thanh toán

### 🔹 Người mua (Buyer)
- Duyệt, tìm kiếm đồng hồ vintage đang bán
- Đặt mua, thanh toán qua nền tảng
- Nhận xác nhận, theo dõi quá trình giao hàng

### 🔹 Quản trị viên (Admin)
- Quản lý sản phẩm, người dùng, giao dịch
- Theo dõi báo cáo doanh thu, tình trạng giao dịch, inventory
- Cấu hình phí/giá dịch vụ, quản lý giấy tờ thẩm định

---

## 🛠 Công nghệ sử dụng / Technology Stack

- **Frontend:** ReactJS / Next.js / VueJS (tùy chọn)
- **Backend:** Node.js (Express) / NestJS / Java Spring Boot (tùy chọn)
- **Database:** PostgreSQL / MongoDB
- **Authentication:** JWT, OAuth2, 2FA
- **File Storage:** AWS S3 / Google Cloud Storage
- **Notification:** Email, SMS, Web Push (Firebase)
- **Payment Gateway:** VNPay, Momo, Stripe
- **CI/CD:** GitHub Actions
- **Cloud Hosting:** AWS / GCP / Azure

---

## 🚀 Cài đặt / Installation

### Yêu cầu hệ thống / Prerequisites

- Node.js >= 18.x
- npm / yarn
- PostgreSQL / MongoDB instance
- Git

### Các bước cài đặt / Setup Steps

```bash
# Clone repository
git clone https://github.com/HuynhManh162/VintageTimepiece.git
cd VintageTimepiece

# Install backend dependencies
cd backend
npm install

# Create .env file and configure database, payment, email...

# Install frontend dependencies
cd ../frontend
npm install
```

### Chạy ứng dụng / Run Application

```bash
# Start backend
cd backend
npm run dev

# Start frontend
cd ../frontend
npm run dev
```

---

## 📱 Sử dụng / Usage

### Quy trình bán & thẩm định đồng hồ

1. **Gửi đồng hồ thẩm định trên web:**
    - Điền form, gửi hình ảnh đồng hồ.
    - Nhận thông báo khi công ty nhận được đồng hồ.

2. **Chờ kết quả thẩm định (2-3 ngày):**
    - Kết quả gửi về qua web/email:
        - **Đồng ý giá:** Đồng hồ niêm yết bán trên web, giao đồng hồ cho công ty.
        - **Không đồng ý:** Thanh toán phí thẩm định, nhận lại đồng hồ + giấy tờ.

3. **Đăng ký bán lại trong vòng 6 tháng:**
    - Gửi giấy tờ thẩm định hợp lệ + đồng hồ.

4. **Sau khi bán thành công:**
    - Tiền chuyển về tài khoản công ty.
    - Xác nhận giao dịch → Công ty chuyển tiền cho người bán.

### Quy trình mua đồng hồ

1. Duyệt sản phẩm trên web.
2. Đặt mua, thanh toán về tài khoản công ty.
3. Nhận xác nhận & giao hàng.
4. Sau khi hoàn thành giao dịch, công ty chuyển tiền cho người bán.

---

## 🤝 Đóng góp / Contributing

Chúng tôi hoan nghênh mọi đóng góp:

- 🍴 Fork repository
- 🌿 Tạo branch mới: `git checkout -b feature/AmazingFeature`
- 💾 Commit & push thay đổi
- 🔀 Gửi Pull Request

**Coding Standards:**
- Tuân thủ style guide của framework sử dụng (React/Node)
- Viết unit test cho tính năng mới
- Cập nhật tài liệu khi có thay đổi logic
- Hỗ trợ song ngữ (VI/EN) nếu có thể

---

## 📄 Giấy phép / License

MIT License

---

## 📞 Hỗ trợ / Support

- 📧 Email: huynhmanh162@gmail.com
- 🐛 Bug Reports: GitHub Issues
- 📖 Documentation: Wiki (coming soon)

---

**Vintage Timepiece Marketplace** – Đảm bảo giao dịch minh bạch, thẩm định chuẩn xác, mua bán an toàn!
