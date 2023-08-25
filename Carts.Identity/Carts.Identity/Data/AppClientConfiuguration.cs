using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carts.Identity.Data
{
    public class AppClientConfiuguration : IEntityTypeConfiguration<AppClient>
    {
        public void Configure(EntityTypeBuilder<AppClient> builder)
        {
            builder.HasKey(m_id => m_id.Id);
        }
    }
}
