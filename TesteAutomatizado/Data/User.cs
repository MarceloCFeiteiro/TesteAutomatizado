﻿using System;

namespace TesteAutomatizado.Data
{
    /// <summary>
    /// Classe reesponsável por armazenar informações de um usuário
    /// </summary>
    public class User
    {
        /// <summary>
        /// Obtém ou define Sexo.
        /// </summary>
        public char Sexo { get; set; }

        /// <summary>
        /// Obtém ou define PrimeiroNome.
        /// </summary>
        public string PrimeiroNome { get; set; }

        /// <summary>
        /// Obtém ou define UltimoNome.
        /// </summary>
        public string UltimoNome { get; set; }

        /// <summary>
        /// Obtém ou define Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Obtém ou define NomeCompleto.
        /// </summary>
        public string NomeCompleto { get { return $"{ PrimeiroNome} {UltimoNome}"; } }

        /// <summary>
        /// Obtém ou define Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define DataAniversario.
        /// </summary>
        public DateTime DataAniversario { get; set; }

        /// <summary>
        /// Obtém ou define Empresa.
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// Obtém ou define EmpresaEndereco.
        /// </summary>
        public string EmpresaEndereco { get; set; }

        /// <summary>
        /// Obtém ou define Cidade.
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Obtém ou define Estado.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Obtém ou define Cep.
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Obtém ou define País.
        /// </summary>
        public string Pais { get; set; }

        /// <summary>
        /// Obtém ou define InformacaoAdicional.
        /// </summary>
        public string InformacaoAdicional { get; set; }

        /// <summary>
        /// Obtém ou define TelefoneComDDD.
        /// </summary>
        public string TelefoneComDDD { get; set; }

        /// <summary>
        /// Obtém ou define CelularComDDD.
        /// </summary>
        public string CelularComDDD { get; set; }


        /// <summary>
        /// Método responsável por criar um usuario para uso no sistema.
        /// </summary>
        /// <returns></returns>
        public User UsuarioPadrao()
        {

            return new User
            {
                Sexo = Faker.Boolean.Random() ? 'F' : 'M',
                PrimeiroNome = Faker.Name.First(),
                UltimoNome = Faker.Name.Last(),
                Password = "aaa123",
                Email = Faker.Internet.Email(this.PrimeiroNome),
                DataAniversario = DateTime.Now.AddYears(-20),
                Empresa = Faker.Company.Name(),
                EmpresaEndereco = Faker.Address.StreetAddress(),
                Cidade = Faker.Address.City(),
                Estado = Faker.Address.UsState(),
                Cep = Faker.Address.ZipCode(),
                Pais = "United States",
                InformacaoAdicional = Faker.Lorem.Paragraph(),
                TelefoneComDDD = Faker.Phone.Number(),
                CelularComDDD = Faker.Phone.Number(),
            };
        }
    }
}
