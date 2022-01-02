using AutoMapper.Business.AutoMapperImplementation.Configuration;
using AutoMapper.Business.Request;
using AutoMapper.Business.Response;
using AutoMapper.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace AutoMapper.Test.Domain.Entities
{
    public class BaseVehicle
    {
        public Vehicle VehicleDomain { get; set; }
        public VehicleRequest VehicleRequest { get; set; }

        public BaseVehicle()
        {
            DomainData();
            RequestData();

            AutoMapperConfiguration.Initialize();
        }

        private void DomainData()
        {
            var manufacture = new Manufacturer
            {
                Id = 3,
                ManufacturerName = "BMW",
                Description = "História do fabricante"
            };

            this.VehicleDomain = new Vehicle
            {
                Id = 1,
                ModelName = "X6",
                VehicleDetails = "Motor v6 Completo",
                Manufacturer = manufacture,
                Price = 500.000m
            };
        }

        private void RequestData()
        {
            var manufacture = new ManufacturerRequest
            {
                Id = 5,
                ManufacturerName = "Jaguar",
                Description = "História do fabricante"
            };

            this.VehicleRequest = new VehicleRequest
            {
                Id = 1,
                ModelName = "JJ8",
                VehicleDetails = "Motor v6 Completo",
                Manufacturer = manufacture,
                Price = 366.000m
            };
        }
    }

    [Collection("AutoMapper Vehicle testings #1")]
    public class VehicleTest1 : BaseVehicle
    {

        [Fact]
        [Trait("Request to domain", "Valid state")]
        public void ValidateDataFromRequestToDomain_UsingFluentAssertions_ResultValidState()
        {
            var vehicle = this.VehicleRequest.MapTo<VehicleRequest, Vehicle>();

            Action action = () => this.VehicleRequest.Should().BeEquivalentTo(vehicle, options =>
            options
            .Including(v => v.Id)
            .Including(v => v.ModelName)
            .Including(v => v.VehicleDetails)
            .Including(v => v.Manufacturer)
            .Including(v => v.Price));

            action.Should().NotThrow();
        }

        [Fact]
        [Trait("Request to response", "Valid state")]
        public void ValidateDataFromDomainToResponse_UsingFluentAssertions_ResultValidState()
        {
            var vehicle = this.VehicleDomain.MapTo<Vehicle, VehicleResponse>();

            Action action = () => this.VehicleDomain.Should().BeEquivalentTo(vehicle, options =>
            options
            .Including(v => v.Id)
            .Including(v => v.ModelName)
            .Including(v => v.VehicleDetails)
            .Including(v => v.Manufacturer)
            .Including(v => v.Price));

            action.Should().NotThrow();
        }
    }

    [Collection("AutoMapper Vehicle testings #2")]
    public class VehicleTest2 : BaseVehicle
    {
        [Fact]
        [Trait("Request to domain", "Valid state")]
        public void ValidateDataFromRequestToDomain_UsingEquals_ResultValidState()
        {
            var vehicle = this.VehicleRequest.MapTo<VehicleRequest, Vehicle>();

            Assert.Equal(vehicle.Id, this.VehicleRequest.Id);
            Assert.Equal(vehicle.ModelName, this.VehicleRequest.ModelName);
            Assert.Equal(vehicle.VehicleDetails, this.VehicleRequest.VehicleDetails);
            Assert.Equal(vehicle.Manufacturer.Id, this.VehicleRequest.Manufacturer.Id);
            Assert.Equal(vehicle.Manufacturer.ManufacturerName, this.VehicleRequest.Manufacturer.ManufacturerName);
            Assert.Equal(vehicle.Manufacturer.Description, this.VehicleRequest.Manufacturer.Description);
            Assert.Equal(vehicle.Price, this.VehicleRequest.Price);
        }

        [Fact]
        [Trait("Request to response", "Valid state")]
        public void ValidateDataFromDomainToResponse_UsingEquals_ResultValidState()
        {
            var vehicle = this.VehicleDomain.MapTo<Vehicle, VehicleResponse>();

            Assert.Equal(vehicle.Id, this.VehicleDomain.Id);
            Assert.Equal(vehicle.ModelName, this.VehicleDomain.ModelName);
            Assert.Equal(vehicle.VehicleDetails, this.VehicleDomain.VehicleDetails);
            Assert.Equal(vehicle.Manufacturer.Id, this.VehicleDomain.Manufacturer.Id);
            Assert.Equal(vehicle.Manufacturer.ManufacturerName, this.VehicleDomain.Manufacturer.ManufacturerName);
            Assert.Equal(vehicle.Manufacturer.Description, this.VehicleDomain.Manufacturer.Description);
            Assert.Equal(vehicle.Price, this.VehicleDomain.Price);
        }
    }
}
