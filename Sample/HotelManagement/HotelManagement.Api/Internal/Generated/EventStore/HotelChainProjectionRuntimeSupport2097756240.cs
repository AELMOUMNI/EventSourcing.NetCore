// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: HotelChainProjectionLiveAggregation2097756240
    public class HotelChainProjectionLiveAggregation2097756240 : Marten.Events.Aggregation.SyncLiveAggregatorBase<HotelChain>
    {
        private readonly HotelChainProjection _hotelChainProjection;

        public HotelChainProjectionLiveAggregation2097756240(HotelChainProjection hotelChainProjection)
        {
            _hotelChainProjection = hotelChainProjection;
        }



        public override HotelChain Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, HotelChain snapshot)
        {
            if (!events.Any()) return null;
            HotelChain hotelChain = null;
            snapshot ??= Create(events[0], session);
            foreach (var @event in events)
            {
                snapshot = Apply(@event, snapshot, session);
            }

            return snapshot;
        }


        public HotelChain Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<HotelChainSetUp> event_HotelChainSetUp1:
                    return HotelChainProjection.Create(event_HotelChainSetUp1.Data);
                    break;
            }

            throw new System.InvalidOperationException("There is no default constructor for HotelChain");
        }


        public HotelChain Apply(Marten.Events.IEvent @event, HotelChain aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<HotelChainNameChanged> event_HotelChainNameChanged2:
                    aggregate = _hotelChainProjection.Apply(event_HotelChainNameChanged2.Data, aggregate);
                    break;
            }

            return aggregate;
        }

    }

    // END: HotelChainProjectionLiveAggregation2097756240
    
    
    // START: HotelChainProjectionInlineHandler2097756240
    public class HotelChainProjectionInlineHandler2097756240 : Marten.Events.Aggregation.AggregationRuntime<HotelChain, System.Guid>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<HotelChain, System.Guid> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<HotelChain, System.Guid> _storage;
        private readonly HotelChainProjection _hotelChainProjection;

        public HotelChainProjectionInlineHandler2097756240(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<HotelChain, System.Guid> slicer, Marten.Internal.Storage.IDocumentStorage<HotelChain, System.Guid> storage, HotelChainProjection hotelChainProjection) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _hotelChainProjection = hotelChainProjection;
        }



        public override async System.Threading.Tasks.ValueTask<HotelChain> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<HotelChain, System.Guid> slice, Marten.Events.IEvent evt, HotelChain aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<HotelChainNameChanged> event_HotelChainNameChanged4:
                    if(aggregate == default) throw new Marten.Exceptions.InvalidProjectionException("Projection for HotelChain should either have the Create Method or Constructor for event of type Marten.Events.IEvent<HotelChainNameChanged>, or HotelChain should have a Default Constructor.");
                    aggregate = _hotelChainProjection.Apply(event_HotelChainNameChanged4.Data, aggregate);
                    return aggregate;
                case Marten.Events.IEvent<HotelChainSetUp> event_HotelChainSetUp5:
                    aggregate = HotelChainProjection.Create(event_HotelChainSetUp5.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public HotelChain Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<HotelChainSetUp> event_HotelChainSetUp3:
                    return HotelChainProjection.Create(event_HotelChainSetUp3.Data);
                    break;
            }

            throw new System.InvalidOperationException("There is no default constructor for HotelChain");
        }

    }

    // END: HotelChainProjectionInlineHandler2097756240
    
    
}

