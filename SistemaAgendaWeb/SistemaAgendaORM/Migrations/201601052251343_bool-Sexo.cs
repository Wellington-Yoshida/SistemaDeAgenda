namespace SistemaAgendaORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolSexo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        TelefoneFixo = c.String(),
                        Celular = c.String(),
                        Email = c.String(),
                        Masculino = c.Boolean(nullable: false),
                        Feminino = c.Boolean(nullable: false),
                        Imagem = c.Binary(),
                        ImagemTipo = c.String(),
                    })
                .PrimaryKey(t => t.ContatoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contato");
        }
    }
}
