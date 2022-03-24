using Anbe.Areas.AnbeAdmin.Models;
using Anbe.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Anbe.Models.Services
{
    public interface IChatRoomService
    {
        Task<Guid> CreateChatRoom(string ConnectionId);
        Task<Guid> GetChatRoomForConnection(string CoonectionId);
        Task<List<Guid>> GetAllrooms();
    }

    public class ChatRoomService : IChatRoomService
    {
        private readonly AnbeContext _context;
        public ChatRoomService(AnbeContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateChatRoom(string ConnectionId)
        {
            var existChatRoom = _context.ChatRooms.SingleOrDefault(p => p.ConnectionId == ConnectionId);
            if(existChatRoom != null)
            {
                return await Task.FromResult(existChatRoom.ID);
            }

            ChatRoom chatRoom = new ChatRoom()
            {
                ConnectionId = ConnectionId,
                ID = Guid.NewGuid(),
            };
            _context.ChatRooms.Add(chatRoom);
            _context.SaveChanges();
            return await Task.FromResult(chatRoom.ID);
        }

        public async Task<List<Guid>> GetAllrooms()
        {
            var rooms = _context.ChatRooms.Include(p=>p.ChatMessages).Where(p=>p.ChatMessages.Any()).Select(x => x.ID).ToList();
            return await Task.FromResult(rooms);
        }

        public async Task<Guid> GetChatRoomForConnection(string CoonectionId)
        {
            var chatRoom = _context.ChatRooms.SingleOrDefault(p => p.ConnectionId == CoonectionId);
            return await Task.FromResult(chatRoom.ID);
        }
    }
}
