using Rescaptepet.Domain.Entities.Public;
using Microsoft.EntityFrameworkCore;

namespace Rescaptepet.Infraestructure.Connections;

public partial class MySqlDbContext : DbContext
{
    public MySqlDbContext() { }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

    // Add the entities to database

    public virtual DbSet<Adopcione> Adopciones { get; set; }

    public virtual DbSet<AnimalFederacion> AnimalFederacions { get; set; }

    public virtual DbSet<Animale> Animales { get; set; }

    public virtual DbSet<Federacione> Federaciones { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<Padrino> Padrinos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<ReportesMejora> ReportesMejoras { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TipoAnimal> TipoAnimals { get; set; }

    public virtual DbSet<TrazabilidadAnimal> TrazabilidadAnimals { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    // Add the atributes and configurations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adopcione>(entity =>
        {
            entity.HasKey(e => e.IdAdopcion).HasName("PRIMARY");

            entity.ToTable("adopciones");

            entity.HasIndex(e => e.IdAnimal, "id_animal");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdAdopcion).HasColumnName("id_adopcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAdopcion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_adopcion");
            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.Adopciones)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("adopciones_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Adopciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("adopciones_ibfk_1");
        });

        modelBuilder.Entity<AnimalFederacion>(entity =>
        {
            entity.HasKey(e => e.IdAnimalFed).HasName("PRIMARY");

            entity.ToTable("animal_federacion");

            entity.HasIndex(e => e.IdAnimal, "id_animal");

            entity.HasIndex(e => e.IdFederacion, "id_federacion");

            entity.Property(e => e.IdAnimalFed).HasColumnName("id_animal_fed");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.IdFederacion).HasColumnName("id_federacion");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.AnimalFederacions)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("animal_federacion_ibfk_1");

            entity.HasOne(d => d.IdFederacionNavigation).WithMany(p => p.AnimalFederacions)
                .HasForeignKey(d => d.IdFederacion)
                .HasConstraintName("animal_federacion_ibfk_2");
        });

        modelBuilder.Entity<Animale>(entity =>
        {
            entity.HasKey(e => e.IdAnimal).HasName("PRIMARY");

            entity.ToTable("animales");

            entity.HasIndex(e => e.IdTipoAnimal, "id_tipo_animal");

            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.EstadoAdopcion)
                .HasMaxLength(50)
                .HasColumnName("estado_adopcion");
            entity.Property(e => e.EstadoSalud)
                .HasMaxLength(100)
                .HasColumnName("estado_salud");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(255)
                .HasColumnName("foto_url");
            entity.Property(e => e.IdTipoAnimal).HasColumnName("id_tipo_animal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("sexo");

            entity.HasOne(d => d.IdTipoAnimalNavigation).WithMany(p => p.Animales)
                .HasForeignKey(d => d.IdTipoAnimal)
                .HasConstraintName("animales_ibfk_1");
        });

        modelBuilder.Entity<Federacione>(entity =>
        {
            entity.HasKey(e => e.IdFederacion).HasName("PRIMARY");

            entity.ToTable("federaciones");

            entity.Property(e => e.IdFederacion).HasColumnName("id_federacion");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Responsable)
                .HasMaxLength(100)
                .HasColumnName("responsable");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PRIMARY");

            entity.ToTable("historial_medico");

            entity.HasIndex(e => e.IdAnimal, "id_animal");

            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.Veterinario)
                .HasMaxLength(100)
                .HasColumnName("veterinario");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("historial_medico_ibfk_1");
        });

        modelBuilder.Entity<Padrino>(entity =>
        {
            entity.HasKey(e => e.IdPadrino).HasName("PRIMARY");

            entity.ToTable("padrinos");

            entity.HasIndex(e => e.IdAnimal, "id_animal");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdPadrino).HasColumnName("id_padrino");
            entity.Property(e => e.DescripcionAporte)
                .HasColumnType("text")
                .HasColumnName("descripcion_aporte");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TipoApadrinamiento)
                .HasMaxLength(100)
                .HasColumnName("tipo_apadrinamiento");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.Padrinos)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("padrinos_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Padrinos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("padrinos_ibfk_1");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PRIMARY");

            entity.ToTable("permisos");

            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(100)
                .HasColumnName("nombre_permiso");
        });

        modelBuilder.Entity<ReportesMejora>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PRIMARY");

            entity.ToTable("reportes_mejora");

            entity.HasIndex(e => e.IdAnimal, "id_animal");

            entity.Property(e => e.IdReporte).HasColumnName("id_reporte");
            entity.Property(e => e.Comportamiento)
                .HasColumnType("text")
                .HasColumnName("comportamiento");
            entity.Property(e => e.EstadoAnimo)
                .HasMaxLength(50)
                .HasColumnName("estado_animo");
            entity.Property(e => e.EvaluacionGeneral)
                .HasColumnType("text")
                .HasColumnName("evaluacion_general");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.Recomendaciones)
                .HasColumnType("text")
                .HasColumnName("recomendaciones");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.ReportesMejoras)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("reportes_mejora_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .HasColumnName("nombre_rol");

            entity.HasMany(d => d.IdPermisos).WithMany(p => p.IdRols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesPermiso",
                    r => r.HasOne<Permiso>().WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("roles_permisos_ibfk_2"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("roles_permisos_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdRol", "IdPermiso")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("roles_permisos");
                        j.HasIndex(new[] { "IdPermiso" }, "id_permiso");
                        j.IndexerProperty<int>("IdRol").HasColumnName("id_rol");
                        j.IndexerProperty<int>("IdPermiso").HasColumnName("id_permiso");
                    });
        });

        modelBuilder.Entity<TipoAnimal>(entity =>
        {
            entity.HasKey(e => e.IdTipoAnimal).HasName("PRIMARY");

            entity.ToTable("tipo_animal");

            entity.Property(e => e.IdTipoAnimal).HasColumnName("id_tipo_animal");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(50)
                .HasColumnName("nombre_tipo");
        });

        modelBuilder.Entity<TrazabilidadAnimal>(entity =>
        {
            entity.HasKey(e => e.IdTraza).HasName("PRIMARY");

            entity.ToTable("trazabilidad_animal");

            entity.HasIndex(e => e.IdAnimal, "id_animal");

            entity.HasIndex(e => e.RegistradoPor, "registrado_por");

            entity.Property(e => e.IdTraza).HasColumnName("id_traza");
            entity.Property(e => e.DescripcionEvento)
                .HasColumnType("text")
                .HasColumnName("descripcion_evento");
            entity.Property(e => e.FechaEvento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_evento");
            entity.Property(e => e.IdAnimal).HasColumnName("id_animal");
            entity.Property(e => e.RegistradoPor).HasColumnName("registrado_por");
            entity.Property(e => e.TipoEvento)
                .HasMaxLength(100)
                .HasColumnName("tipo_evento");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.TrazabilidadAnimals)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("trazabilidad_animal_ibfk_1");

            entity.HasOne(d => d.RegistradoPorNavigation).WithMany(p => p.TrazabilidadAnimals)
                .HasForeignKey(d => d.RegistradoPor)
                .HasConstraintName("trazabilidad_animal_ibfk_2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("usuarios_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

