using AutoMapper.Business.AutoMapperImplementation.Configuration;
using AutoMapper.Business.Request;
using AutoMapper.Business.Response;
using AutoMapper.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace AutoMapper.Test.Domain.Entities
{
    public class BaseManufacturer
    {
        public Manufacturer ManufacturerDomain { get; set; }
        public ManufacturerRequest ManufacturerRequest { get; set; }

        public BaseManufacturer()
        {
            DomainData();
            RequestData();

            AutoMapperConfiguration.Initialize();
        }

        private void DomainData()
        {
            this.ManufacturerDomain =
                new Manufacturer { Id = 1, ManufacturerName = "Ferrari", Description = "Sobre o fabricante" };
        }

        private void RequestData()
        {
            this.ManufacturerRequest =
                new ManufacturerRequest { Id = 3, ManufacturerName = "Hyundai", Description = "Sobre o fabricante" };
        }
    }

    [Collection("AutoMapper Manufacturer testings #1")]
    public class ManufacturerTest1 : BaseManufacturer
    {

        [Fact]
        [Trait("Request to domain", "Valid state")]
        public void ValidateDataFromRequestToDomain_UsingFluentAssertions_ResultValidState()
        {
           var manufacturer = this.ManufacturerRequest.MapTo<ManufacturerRequest, Manufacturer>();

            Action act = () => this.ManufacturerRequest.Should().BeEquivalentTo(manufacturer, options
                => options
                .Including(m => m.Id)
                .Including(m => m.ManufacturerName)
                .Including(m => m.Description));

            act.Should().NotThrow();
        }

       
        [Fact]
        [Trait("Domain to response", "Valid state")]
        public void ValidateDataFromDomainToResponse_UsingFluentAssertions_ResultValidState()
        {
            var manufacturer = this.ManufacturerDomain.MapTo<Manufacturer, ManufacturerResponse>();

            Action act = () => this.ManufacturerDomain.Should().BeEquivalentTo(manufacturer, options
                => options
                .Including(m => m.Id)
                .Including(m => m.ManufacturerName)
                .Including(m => m.Description));

            act.Should().NotThrow();
        }
    }

    [Collection("AutoMapper Testings #2")]
    public class ManufacturerTest2 : BaseManufacturer
    {
        [Fact]
        [Trait("Request to domain", "Valid state")]
        public void ValidateDataFromRequestToDomain_UsingEquals_ResultIsTrue()
        {
            var manufacturer = this.ManufacturerRequest.MapTo<ManufacturerRequest, Manufacturer>();

            Assert.Equal(manufacturer.Id, this.ManufacturerRequest.Id);
            Assert.Equal(manufacturer.ManufacturerName, this.ManufacturerRequest.ManufacturerName);
            Assert.Equal(manufacturer.Description, this.ManufacturerRequest.Description);
        }

        [Fact]
        [Trait("Domain to response", "Valid state")]
        public void ValidateDataFromDomainToResponse_UsingEquals_ResultIsTrue()
        {
            var manufacturer = this.ManufacturerDomain.MapTo<Manufacturer, ManufacturerResponse>();

            Assert.Equal(manufacturer.Id, this.ManufacturerDomain.Id);
            Assert.Equal(manufacturer.ManufacturerName, this.ManufacturerDomain.ManufacturerName);
            Assert.Equal(manufacturer.Description, this.ManufacturerDomain.Description);
        }
    }
}
