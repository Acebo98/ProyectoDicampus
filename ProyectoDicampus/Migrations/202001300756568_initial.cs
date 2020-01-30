namespace ProyectoDicampus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Respuesta1 = c.String(nullable: false, maxLength: 100),
                        Respuesta2 = c.String(nullable: false, maxLength: 100),
                        Respuesta3 = c.String(nullable: false, maxLength: 100),
                        Respuesta4 = c.String(nullable: false, maxLength: 100),
                        Correcta = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        Genero = c.Boolean(nullable: false),
                        Puntuacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preguntas", "UsuarioID", "dbo.Usuarios");
            DropIndex("dbo.Preguntas", new[] { "UsuarioID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Preguntas");
        }
    }
}
