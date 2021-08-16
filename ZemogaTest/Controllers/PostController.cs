using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;
using ZemogaTest.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZemogaTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/<PostController>
        [HttpGet]
        [Route("GetAllPublisedPost")]
        public async Task<ActionResult<ApiResponse>> GetAllPublisedPost()
        {
            var result = await _postService.GetAllPublisedPosts();
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET: api/<PostController>
        [HttpGet]
        [Route("GetAllPendigForApprovalPost")]
        public async Task<ActionResult<ApiResponse>> GetAllPendigForApprovalPost()
        {
            var result = await _postService.GetAllPendingForApprovalPost();
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // GET: api/<PostController>/userName
        [HttpGet("{writerUserName}")]
        public async Task<ActionResult<ApiResponse>> GetAllPostByWriter(string writerUserName)
        {
            var result = await _postService.GetAllPostByWriter(writerUserName);
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        //// GET api/<PostController>/5
        //[HttpGet("{postId}")]
        //public async Task<ActionResult<ApiResponse>> Get(Guid postId)
        //{
        //    var result = await _postService.GetPost(postId);
        //    if (result is ErrorResponse)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        // POST api/<PostController>
        [HttpPost]
        [Route("CreatePost")]
        public async Task<ActionResult<ApiResponse>> CreatePost([FromBody] CreatePostRequest request)
        {
            var result = await _postService.CreatePost(request);
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<PostController>
        [HttpPost]
        [Route("SendPostForApproval")]
        public async Task<ActionResult<ApiResponse>> SendPostForApproval([FromBody] SendPostForApprovalRequest sendForApprovalRequest)
        {
            var result = await _postService.SendForApproval(sendForApprovalRequest);
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<PostController>
        [HttpPost]
        [Route("ApproveOrReject")]
        public async Task<ActionResult<ApiResponse>> ApproveOrRejectPost([FromBody] ApproveOrRejectPost approveOrRejectPostRequest)
        {
            var result = await _postService.ApproveOrReject(approveOrRejectPostRequest);
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("AddComment")]
        public async Task<ActionResult<ApiResponse>> AddComment([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<PostController>/
        [HttpPut]
        [Route("EditPost")]
        public async Task<ActionResult<ApiResponse>> EditPost([FromBody] EditPostequest editPostequest)
        {
            var result = await _postService.EditPost(editPostequest);
            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
