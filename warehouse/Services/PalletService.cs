using AutoMapper;
using Microsoft.EntityFrameworkCore;
using warehouse.Create;
using warehouse.Database;
using warehouse.Entities;

namespace warehouse.Services;

public interface IPalletService
{
    string? Create(CreatePallet input);
    IEnumerable<Pallet>?  GetAll();
    Pallet?  GetById(int palletId);
    bool Remove(int palletId);
    bool ChangeStatus(int palletId, string status);
}

public class PalletService : IPalletService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PalletService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public string? Create(CreatePallet input)
    {
        var ids = input.packageIds.Split(';');
        var boxes = _context.Boxes
            .Where(x => ids.Contains(x.Id.ToString()))
            .ToList();
        var pallet = new PalletEntity();
        pallet.Client = _context.Clients.First(x=>x.Id==input.ClientId);
        pallet.Address= _context.Addresses.First(d=> d.Id== input.AddressId);
        pallet.StatusId= input.StatusId;
        _context.SaveChanges();
        foreach (var box in boxes)
        {
            box.Pallet = pallet;
        }
        _context.SaveChanges();
        return $"/api/pallet/{pallet.Id}";
    }
    public IEnumerable<Pallet>?  GetAll()
    {
        var pallets = _context.Pallets
            .Include(c=>c.Status)
            .Include(c=>c.Client)
            .Include(c=>c.Address)
            .ToList();
        return _mapper.Map<List<Pallet>>(pallets);
    }
    public Pallet?  GetById(int palletId)
    {
        var pallet = _context.Pallets
            .Include(c=>c.Status)
            .Include(c=>c.Client)
            .Include(c=>c.Address)
            .FirstOrDefault(x=>x.Id == palletId);
        return _mapper.Map<Pallet>(pallet);
    }
    public bool Remove(int palletId)
    {
        var pallet = _context.Pallets.Include(c=>c.Boxes).FirstOrDefault((x => x.Id == palletId));
        if (pallet == null) return false;
        foreach (BoxEntity x in pallet.Boxes)
        {
            x.PalletId = null;
        }

        _context.Pallets.Remove(pallet);
        _context.SaveChanges();
        return true;
    }
    public bool ChangeStatus(int palletId, string status)
    {
        var pallet = _context.Pallets.Include(c=>c.Boxes).FirstOrDefault((x => x.Id == palletId));
        if (pallet == null) return false;
        pallet.Status = _context.Status.First(x => x.Name==status);
        foreach (BoxEntity box in pallet.Boxes)
        {
            box.Status = pallet.Status;
        }
        _context.SaveChanges();
        return true;
    }
    
}