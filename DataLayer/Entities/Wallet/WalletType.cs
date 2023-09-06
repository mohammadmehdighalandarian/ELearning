using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Wallet
{
    public class WalletType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string TypeTitle { get; set; }

        public WalletType()
        {
            
        }

        #region Relation

        public virtual List<Wallet> Wallets { get; set; }

        #endregion
    }
}
