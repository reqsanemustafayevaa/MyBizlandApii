using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Configurations
{
    public class MemberProfessionConfiguration : IEntityTypeConfiguration<MemberProfession>
    {
        public void Configure(EntityTypeBuilder<MemberProfession> builder)
        {
            builder.HasOne(x => x.Profession).WithMany(x => x.MemberProfessions).HasForeignKey(x => x.ProfessionId);
            builder.HasOne(x => x.Member).WithMany(x => x.MemberProfessions).HasForeignKey(x => x.MemberId);
        }
    }
}
