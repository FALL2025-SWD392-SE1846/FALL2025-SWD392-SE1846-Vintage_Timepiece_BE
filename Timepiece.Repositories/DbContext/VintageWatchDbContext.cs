using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Timepiece.Repositories.Models;

public partial class VintageWatchDbContext : DbContext
{
    public VintageWatchDbContext()
    {
    }

    public VintageWatchDbContext(DbContextOptions<VintageWatchDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<account> accounts { get; set; }

    public virtual DbSet<appraisalreport> appraisalreports { get; set; }

    public virtual DbSet<appraisalrequest> appraisalrequests { get; set; }

    public virtual DbSet<blogpost> blogposts { get; set; }

    public virtual DbSet<cart> carts { get; set; }

    public virtual DbSet<cartitem> cartitems { get; set; }

    public virtual DbSet<conversation> conversations { get; set; }

    public virtual DbSet<message> messages { get; set; }

    public virtual DbSet<notification> notifications { get; set; }

    public virtual DbSet<order> orders { get; set; }

    public virtual DbSet<ordervoucher> ordervouchers { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<productmedium> productmedia { get; set; }

    public virtual DbSet<review> reviews { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<transaction> transactions { get; set; }

    public virtual DbSet<useraddress> useraddresses { get; set; }

    public virtual DbSet<voucher> vouchers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("media_type", new[] { "image", "video", "image_360" })
            .HasPostgresEnum("order_status", new[] { "pending_payment", "confirmed", "shipping", "delivered", "cancelled", "failed" })
            .HasPostgresEnum("product_status", new[] { "for_sale", "in_cart", "sold", "delisted" })
            .HasPostgresEnum("request_status", new[] { "pending_receipt", "rejected", "appraising", "price_quoted", "seller_accepted", "seller_rejected", "listing_in_progress", "listed", "returned" })
            .HasPostgresEnum("user_role", new[] { "buyer", "seller", "appraiser", "admin" });

        modelBuilder.Entity<account>(entity =>
        {
            entity.HasKey(e => e.account_id).HasName("accounts_pkey");

            entity.Property(e => e.account_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.role).WithMany(p => p.accounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accounts_role_id_fkey");
        });

        modelBuilder.Entity<appraisalreport>(entity =>
        {
            entity.HasKey(e => e.report_id).HasName("appraisalreports_pkey");

            entity.Property(e => e.report_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.appraiser).WithMany(p => p.appraisalreports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appraisalreports_appraiser_id_fkey");

            entity.HasOne(d => d.request).WithOne(p => p.appraisalreport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appraisalreports_request_id_fkey");
        });

        modelBuilder.Entity<appraisalrequest>(entity =>
        {
            entity.HasKey(e => e.request_id).HasName("appraisalrequests_pkey");

            entity.Property(e => e.request_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.seller).WithMany(p => p.appraisalrequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appraisalrequests_seller_id_fkey");
        });

        modelBuilder.Entity<blogpost>(entity =>
        {
            entity.HasKey(e => e.post_id).HasName("blogposts_pkey");

            entity.Property(e => e.post_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.status).HasDefaultValueSql("'draft'::character varying");

            entity.HasOne(d => d.author).WithMany(p => p.blogposts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("blogposts_author_id_fkey");
        });

        modelBuilder.Entity<cart>(entity =>
        {
            entity.HasKey(e => e.cart_id).HasName("carts_pkey");

            entity.Property(e => e.cart_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.account).WithOne(p => p.cart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carts_account_id_fkey");
        });

        modelBuilder.Entity<cartitem>(entity =>
        {
            entity.HasKey(e => e.cart_item_id).HasName("cartitems_pkey");

            entity.Property(e => e.cart_item_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.added_at).HasDefaultValueSql("now()");
            entity.Property(e => e.quantity).HasDefaultValue(1);

            entity.HasOne(d => d.cart).WithMany(p => p.cartitems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cartitems_cart_id_fkey");

            entity.HasOne(d => d.product).WithOne(p => p.cartitem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cartitems_product_id_fkey");
        });

        modelBuilder.Entity<conversation>(entity =>
        {
            entity.HasKey(e => e.conversation_id).HasName("conversations_pkey");

            entity.Property(e => e.conversation_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.request).WithOne(p => p.conversation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conversations_request_id_fkey");
        });

        modelBuilder.Entity<message>(entity =>
        {
            entity.HasKey(e => e.message_id).HasName("messages_pkey");

            entity.Property(e => e.message_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.is_read).HasDefaultValue(false);
            entity.Property(e => e.sent_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.conversation).WithMany(p => p.messages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("messages_conversation_id_fkey");

            entity.HasOne(d => d.sender).WithMany(p => p.messages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("messages_sender_id_fkey");
        });

        modelBuilder.Entity<notification>(entity =>
        {
            entity.HasKey(e => e.notification_id).HasName("notifications_pkey");

            entity.Property(e => e.notification_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_read).HasDefaultValue(false);

            entity.HasOne(d => d.account).WithMany(p => p.notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notifications_account_id_fkey");
        });

        modelBuilder.Entity<order>(entity =>
        {
            entity.HasKey(e => e.order_id).HasName("orders_pkey");

            entity.Property(e => e.order_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.discount_amount).HasDefaultValueSql("0");
            entity.Property(e => e.shipping_fee).HasDefaultValueSql("0");

            entity.HasOne(d => d.buyer).WithMany(p => p.orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_buyer_id_fkey");

            entity.HasOne(d => d.product).WithOne(p => p.order)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_product_id_fkey");
        });

        modelBuilder.Entity<ordervoucher>(entity =>
        {
            entity.HasKey(e => new { e.order_id, e.voucher_id }).HasName("ordervouchers_pkey");

            entity.Property(e => e.applied_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.order).WithMany(p => p.ordervouchers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordervouchers_order_id_fkey");

            entity.HasOne(d => d.voucher).WithMany(p => p.ordervouchers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordervouchers_voucher_id_fkey");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.product_id).HasName("products_pkey");

            entity.Property(e => e.product_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.listed_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.report).WithOne(p => p.product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_report_id_fkey");

            entity.HasOne(d => d.request).WithOne(p => p.product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_request_id_fkey");
        });

        modelBuilder.Entity<productmedium>(entity =>
        {
            entity.HasKey(e => e.media_id).HasName("productmedia_pkey");

            entity.Property(e => e.media_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.display_order).HasDefaultValue(0);
            entity.Property(e => e.uploaded_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.request).WithMany(p => p.productmedia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productmedia_request_id_fkey");
        });

        modelBuilder.Entity<review>(entity =>
        {
            entity.HasKey(e => e.review_id).HasName("reviews_pkey");

            entity.Property(e => e.review_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.account).WithMany(p => p.reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_account_id_fkey");

            entity.HasOne(d => d.order).WithMany(p => p.reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_order_id_fkey");

            entity.HasOne(d => d.product).WithMany(p => p.reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reviews_product_id_fkey");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.role_id).HasName("roles_pkey");

            entity.Property(e => e.role_id).HasDefaultValueSql("gen_random_uuid()");
        });

        modelBuilder.Entity<transaction>(entity =>
        {
            entity.HasKey(e => e.transaction_id).HasName("transactions_pkey");

            entity.Property(e => e.transaction_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.order).WithMany(p => p.transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactions_order_id_fkey");
        });

        modelBuilder.Entity<useraddress>(entity =>
        {
            entity.HasKey(e => e.address_id).HasName("useraddresses_pkey");

            entity.Property(e => e.address_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.is_default).HasDefaultValue(false);

            entity.HasOne(d => d.account).WithMany(p => p.useraddresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useraddresses_account_id_fkey");
        });

        modelBuilder.Entity<voucher>(entity =>
        {
            entity.HasKey(e => e.voucher_id).HasName("vouchers_pkey");

            entity.Property(e => e.voucher_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.current_usage).HasDefaultValue(0);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.min_order_value).HasDefaultValueSql("0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
