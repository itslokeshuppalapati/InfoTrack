using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NSubstitute;
using WebScrapper.Application.Handlers;
using WebScrapper.Application.Queries;
using WebScrapper.Core.Models;
using WebScrapper.Core.Services;
using Xunit;

namespace WebScrapper.Tests.Handlers
{
    [Trait("category", "unit-tests")]
    public class HandlerTests
    {
        private IMediator _mediator;
        private ISearchService _searchService;
        private ISearchHistoryService _searchHistoryService;

        public HandlerTests()
        {
            _searchService = Substitute.For<ISearchService>();
            _searchHistoryService = Substitute.For<ISearchHistoryService>();
            _mediator = Substitute.For<IMediator>();
        }

        [Fact(DisplayName = "GetSearchEnginesQuery_Should_Handle")]
        public async Task GetSearchEnginesQuery_Should_Handle_Successfully()
        {
            //Arrange
            var service = new GetSearchEnginesQueryHandler(_searchService);
            _searchService.GetSearchEnginesAsync().Returns(new List<SearchEngine>());
            //Act
            await service.Handle(new GetSearchEnginesQuery(), CancellationToken.None);
            //Assert
            await _searchService.Received(1).GetSearchEnginesAsync();
        }

        [Fact(DisplayName = "GetSearchResultsQuery_Should_Handle")]
        public async Task GetSearchResultsQuery_Should_Handle_Successfully()
        {
            //Arrange
            var service = new GetSearchResultsHistoryQueryHandler(_searchHistoryService);
            _searchHistoryService.GetAllSearchHistoryAsync().Returns(new List<SearchResult>());
            //Act
            await service.Handle(new GetSearchResultsHistoryQuery(), CancellationToken.None);
            //Assert
            await _searchHistoryService.Received(1).GetAllSearchHistoryAsync();
        }
    }
}
