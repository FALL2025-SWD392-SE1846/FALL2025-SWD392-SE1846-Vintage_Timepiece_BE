1. Overview

Nền tảng hỗ trợ người bán gửi đồng hồ để thẩm định và sau đó đăng bán trên website.
Người mua có thể trực tiếp giao dịch, toàn bộ thanh toán sẽ được trung gian qua công ty để đảm bảo an toàn và minh bạch.

2. Key Features

Appraisal (Thẩm định):

Người bán gửi đồng hồ để được thẩm định giá trị.

Thời gian xử lý trung bình: 2–3 ngày làm việc.

Kết quả thẩm định gồm:

Báo giá đề xuất.

Giấy chứng nhận thẩm định (valid trong vòng 6 tháng).

Selling (Bán):

Người bán có thể đồng ý hoặc từ chối mức giá sau thẩm định.

Nếu đồng ý → đăng ký bán.

Nếu không đồng ý → trả phí thẩm định, nhận lại đồng hồ + giấy chứng nhận.

Marketplace (Mua):

Người mua có thể mua đồng hồ đã được thẩm định và đăng bán.

Thanh toán qua tài khoản công ty.

Sau khi giao dịch hoàn tất, công ty xác nhận và chuyển tiền cho người bán.

3. Workflow
🔹 Seller Flow

Request Appraisal

Người bán gửi đồng hồ lên công ty.

Hệ thống ghi nhận trạng thái: Pending Receipt.

Thông báo khi công ty nhận đồng hồ.

Appraisal Process

Thẩm định trong 2–3 ngày.

Cập nhật kết quả:

Accepted → người bán đồng ý với giá.

Rejected → người bán từ chối, phải thanh toán phí thẩm định.

Selling Registration

Nếu Accepted:

Người bán gửi đồng hồ + giấy thẩm định (còn hạn 6 tháng).

Sau khi công ty nhận → đồng hồ hiển thị trên website marketplace.

Transaction Completion

Khi bán thành công, hệ thống ghi trạng thái: Sold.

🔹 Buyer Flow

Browse & Purchase

Người mua chọn đồng hồ đã đăng bán trên website.

Thanh toán chuyển về tài khoản công ty.

Payment Settlement

Công ty xác nhận giao dịch thành công.

Tiền được chuyển lại cho người bán.

4. Business Rules

Appraisal Validity: giấy chứng nhận có hiệu lực trong vòng 6 tháng.

Disagreement Case: nếu người bán từ chối mức giá, bắt buộc trả phí thẩm định.

Escrow Payment: tiền luôn đi qua công ty trước, sau đó mới trả cho người bán để đảm bảo an toàn.

5. Tech Notes (For Developers)

Entities chính:

User (Buyer / Seller / Appraiser / Admin)

Watch

Appraisal (status: pending, completed, accepted, rejected)

Transaction (status: pending, completed, settled)

States:

Seller: PendingReceipt → Appraising → ResultReturned → SellingRegistered → Listed → Sold

Buyer: Browsing → Purchase → PaymentPending → PaymentConfirmed → SettlementDone

Integration points:

Payment Gateway.

Notification Service (email/SMS).

File Upload (giấy chứng nhận, hình ảnh đồng hồ).

6. Future Improvements

Tích hợp Blockchain certificate cho giấy thẩm định.

Cho phép Auction mode (đấu giá thay vì fixed price).

Thêm Realtime notification khi đồng hồ được mua hoặc có kết quả thẩm định.
