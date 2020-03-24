using Moq;
using NUnit.Framework;
using ProdCode.Telemetry;
using System;

namespace NUnitTests.Telemetry
{
    class TelemetryDiagnosticControlsTest
    {
        private Mock<ITelemetryClient> clientMock;
        private TelemetryDiagnosticControls controls;

        [SetUp]
        public void Init()
        {
            clientMock = new Mock<ITelemetryClient>();
            controls = new TelemetryDiagnosticControls(clientMock.Object);

        }
        [Test]
        public void ThrowsIfNotOnline()
        {
            clientMock.Setup(c => c.GetOnlineStatus()).Returns(false);
            Assert.Throws<Exception>(() => controls.CheckTransmission());
        }

        [Test]
        public void Disconnects()
        {
            clientMock.Setup(c => c.GetOnlineStatus()).Returns(true);
            controls.CheckTransmission();
            clientMock.Verify(c => c.Disconnect());
        }
        [Test]
        public void Sends()
        {
            clientMock.Setup(c => c.GetOnlineStatus()).Returns(true);
            controls.CheckTransmission();
            clientMock.Verify(c => c.Send(TelemetryClient.DIAGNOSTIC_MESSAGE));
        }
        [Test]
        public void Receives()
        {
            clientMock.Setup(c => c.GetOnlineStatus()).Returns(true);
            clientMock.Setup(c => c.Receive()).Returns("GRANPA");

            controls.CheckTransmission();
            // clientMock.Verify(c => c.Receive()); // VERIFY IS ALWAYS REDUNDANT FOR METHODS THAT YOU PROGRAM (setUp)
            // DON'T VERIFY EVERYTHING. DON'T FOR not critical methods.
            // verify: repo.save()   smsSender.send()
            Assert.AreEqual("GRANPA", controls.diagnosticInfo);
        }
    }
}
