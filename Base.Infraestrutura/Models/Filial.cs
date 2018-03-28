using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Infraestrutura.Models
{
    [Table("Filial")]
    public class Filial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("FILI_CD_FILIAL")]
        public int ID { get; set; }
        [Column("REFI_SQ_REGIAO")]
        public int SqRegiao { get; set; }
        [Column("ESTA_SG_UF")]
        public string UF { get; set; }
        [Column("FILI_NM_FANTASIA")]
        public string NomeFantasia { get; set; }
        [Column("FILI_TN_CNPJ")]
        public string CNPJ { get; set; }
    }
}
