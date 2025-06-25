using System;
using System.ComponentModel.DataAnnotations; // Adicione para validações

namespace PwaAppIFMS.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O título da tarefa é obrigatório.")]
        [StringLength(100, ErrorMessage = "O título não pode exceder 100 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição não pode exceder 500 caracteres.")]
        public string? Description { get; set; } // Novo campo: Descrição da tarefa

        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(7); // Novo campo: Data de Vencimento
        public TaskPriority Priority { get; set; } = TaskPriority.Medium; // Novo campo: Prioridade
        public bool IsCompleted { get; set; } = false; // Novo campo: Status (concluída ou não)

        public string? ImageDataUrl { get; set; } // Imagem em Base64

        // Campo para controlar o modo de edição na UI
        public bool IsEditing { get; set; } = false;
    }

    // Enum para a prioridade da tarefa
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
}