using AutoMapper;
using Microsoft.EntityFrameworkCore;
using warehouse.Create;
using warehouse.Database;
using warehouse.Entities;

namespace warehouse.Services;

public interface IBoxService
{
    string? Create(int clientId, CreateBox input);
    IEnumerable<Box>? GetAll();
    Box? GetById(int packageId);
    bool Remove(int packageId);
    public bool ChangeStatus(int packageId, string status);
}

public class BoxService : IBoxService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMessageProducer _messagePublisher;

    public BoxService(AppDbContext context, IMapper mapper, IMessageProducer messagePublisher)
    {
        _context = context;
        _mapper = mapper;
        _messagePublisher = messagePublisher;
    }

    public string? Create(int clientId, CreateBox input)
    {
        var client = GetClientById(clientId);
        if (client is null) return null;
        var shippingAddress = client.Addresses
            .FirstOrDefault(x => x.AddressType == "shipping") ?? client.Addresses.First();
        var box = _mapper.Map<BoxEntity>(input);
        box.Client = client;
        box.Address = shippingAddress;
        box.Status = _context.Status.First(x => x.Name == "prepared");
        
        _context.Boxes.Add(box);
        _context.SaveChanges();
        return $"/api/package/{box.Id}";
    }

    public IEnumerable<Box>?  GetAll()
    {
        var boxes = _context.Boxes
            .Include(c=>c.Status)
            .Include(c=>c.Client)
            .Include(c=>c.Address)
            .ToList();
        return _mapper.Map<List<Box>>(boxes);
    }

    public Box? GetById(int packageId)
    {
        var box = _context.Boxes.Include(c => c.Status)
            .Include(c => c.Client)
            .Include(c => c.Address)
            .FirstOrDefault(x => x.Id == packageId);
        return _mapper.Map<Box>(box);
    }

    public bool Remove(int packageId)
    {
        var box = _context.Boxes.FirstOrDefault((x => x.Id == packageId));
        if (box == null) return false;
        _context.Boxes.Remove(box);
        _context.SaveChanges();
        return true;
    }

    public bool ChangeStatus(int packageId, string status)
    {
        var box = _context.Boxes.FirstOrDefault((x => x.Id == packageId));
        if (box == null) return false;
        box.Status = _context.Status.First(x => x.Name==status);
        _context.SaveChanges();
        return true;
    }

    private ClientEntity? GetClientById(int clientId)
    {
        var client = _context
            .Clients
            .Include(c=>c.Addresses)
            .FirstOrDefault(x => x.Id == clientId);
        return client;
    }
}