// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Localisation;

namespace osu.Game.Localisation
{
    public static class BeatmapSubmissionStrings
    {
        private const string prefix = @"osu.Game.Resources.Localisation.BeatmapSubmission";

        /// <summary>
        /// "Level submission"
        /// </summary>
        public static LocalisableString BeatmapSubmissionTitle => new TranslatableString(getKey(@"beatmap_submission_title"), @"Level submission");

        /// <summary>
        /// "Share your level with everyone who plays kan!"
        /// </summary>
        public static LocalisableString BeatmapSubmissionDescription => new TranslatableString(getKey(@"beatmap_submission_description"), @"Share your level with everyone who plays kan!");

        /// <summary>
        /// "Content permissions"
        /// </summary>
        public static LocalisableString ContentPermissions => new TranslatableString(getKey(@"content_permissions"), @"Content permissions");

        /// <summary>
        /// "I understand"
        /// </summary>
        public static LocalisableString ContentPermissionsAcknowledgement => new TranslatableString(getKey(@"content_permissions_acknowledgement"), @"I understand");

        /// <summary>
        /// "Frequently asked questions"
        /// </summary>
        public static LocalisableString FrequentlyAskedQuestions => new TranslatableString(getKey(@"frequently_asked_questions"), @"Frequently asked questions");

        /// <summary>
        /// "Submission settings"
        /// </summary>
        public static LocalisableString SubmissionSettings => new TranslatableString(getKey(@"submission_settings"), @"Submission settings");

        /// <summary>
        /// "Submit level!"
        /// </summary>
        public static LocalisableString ConfirmSubmission => new TranslatableString(getKey(@"confirm_submission"), @"Submit level!");

        /// <summary>
        /// "Packing the level..."
        /// </summary>
        public static LocalisableString Exporting => new TranslatableString(getKey(@"exporting"), @"Packing the level...");

        /// <summary>
        /// "Preparing for upload..."
        /// </summary>
        public static LocalisableString Preparing => new TranslatableString(getKey(@"preparing"), @"Preparing for upload...");

        /// <summary>
        /// "Uploading the level..."
        /// </summary>
        public static LocalisableString Uploading => new TranslatableString(getKey(@"uploading"), @"Uploading the level...");

        /// <summary>
        /// "Finishing up..."
        /// </summary>
        public static LocalisableString Finishing => new TranslatableString(getKey(@"finishing"), @"Finishing up...");

        /// <summary>
        /// "Before you continue, check that you may share everything in your level: the music (the composition) and every audio file in it. Public domain, CC0, CC BY and CC BY-SA are fine; music under copyright needs its creators' permission. You are responsible for what you upload. Levels that break this rule are removed."
        /// </summary>
        public static LocalisableString ContentPermissionsDisclaimer => new TranslatableString(getKey(@"content_permissions_disclaimer"), @"Before you continue, check that you may share everything in your level: the music (the composition) and every audio file in it. Public domain, CC0, CC BY and CC BY-SA are fine; music under copyright needs its creators' permission. You are responsible for what you upload. Levels that break this rule are removed.");

        /// <summary>
        /// "What you may use (level creator's handbook)"
        /// </summary>
        public static LocalisableString CheckContentUsageGuidelines => new TranslatableString(getKey(@"check_content_usage_guidelines"), @"What you may use (level creator's handbook)");

        /// <summary>
        /// "Level creator's handbook"
        /// </summary>
        public static LocalisableString BeatmapRankingCriteria => new TranslatableString(getKey(@"beatmap_ranking_criteria"), @"Level creator's handbook");

        /// <summary>
        /// "How to make a level that plays well, from the song to the verify checklist."
        /// </summary>
        public static LocalisableString BeatmapRankingCriteriaDescription => new TranslatableString(getKey(@"beatmap_ranking_criteria_description"), @"How to make a level that plays well, from the song to the verify checklist.");

        /// <summary>
        /// "How levels are published"
        /// </summary>
        public static LocalisableString SubmissionProcess => new TranslatableString(getKey(@"submission_process"), @"How levels are published");

        /// <summary>
        /// "From work in progress to pending to ranked: what each step means."
        /// </summary>
        public static LocalisableString SubmissionProcessDescription => new TranslatableString(getKey(@"submission_process_description"), @"From work in progress to pending to ranked: what each step means.");

        /// <summary>
        /// "Ask for help"
        /// </summary>
        public static LocalisableString MappingHelpForum => new TranslatableString(getKey(@"mapping_help_forum"), @"Ask for help");

        /// <summary>
        /// "Questions or problems? Ask on kan!'s issue tracker."
        /// </summary>
        public static LocalisableString MappingHelpForumDescription => new TranslatableString(getKey(@"mapping_help_forum_description"), @"Questions or problems? Ask on kan!'s issue tracker.");

        /// <summary>
        /// "Modding queues forum"
        /// </summary>
        public static LocalisableString ModdingQueuesForum => new TranslatableString(getKey(@"modding_queues_forum"), @"Modding queues forum");

        /// <summary>
        /// "Having trouble getting feedback? Why not ask in a mod queue!"
        /// </summary>
        public static LocalisableString ModdingQueuesForumDescription => new TranslatableString(getKey(@"modding_queues_forum_description"), @"Having trouble getting feedback? Why not ask in a mod queue!");

        /// <summary>
        /// "Where would you like to post your level?"
        /// </summary>
        public static LocalisableString BeatmapSubmissionTargetCaption => new TranslatableString(getKey(@"beatmap_submission_target_caption"), @"Where would you like to post your level?");

        /// <summary>
        /// "Work in progress (not finished; others can try it)"
        /// </summary>
        public static LocalisableString BeatmapSubmissionTargetWIP => new TranslatableString(getKey(@"beatmap_submission_target_wip"), @"Work in progress (not finished; others can try it)");

        /// <summary>
        /// "Pending (finished, ready to be reviewed for ranking)"
        /// </summary>
        public static LocalisableString BeatmapSubmissionTargetPending => new TranslatableString(getKey(@"beatmap_submission_target_pending"), @"Pending (finished, ready to be reviewed for ranking)");

        /// <summary>
        /// "Receive notifications for discussion replies"
        /// </summary>
        public static LocalisableString NotifyOnDiscussionReplies => new TranslatableString(getKey(@"notify_for_discussion_replies"), @"Receive notifications for discussion replies");

        /// <summary>
        /// "Load in browser after submission"
        /// </summary>
        public static LocalisableString LoadInBrowserAfterSubmission => new TranslatableString(getKey(@"load_in_browser_after_submission"), @"Load in browser after submission");

        /// <summary>
        /// "Your level is packed as an .osz, the format kan! shares levels in. Everything the level needs travels with it."
        /// </summary>
        public static LocalisableString LegacyExportDisclaimer => new TranslatableString(getKey(@"legacy_export_disclaimer"), @"Your level is packed as an .osz, the format kan! shares levels in. Everything the level needs travels with it.");

        /// <summary>
        /// "Empty levels cannot be submitted."
        /// </summary>
        public static LocalisableString EmptyBeatmapsCannotBeSubmitted => new TranslatableString(getKey(@"empty_beatmaps_cannot_be_submitted"), @"Empty levels cannot be submitted.");

        /// <summary>
        /// "Update level!"
        /// </summary>
        public static LocalisableString UpdateBeatmap => new TranslatableString(getKey(@"update_beatmap"), @"Update level!");

        /// <summary>
        /// "Upload as a NEW level!"
        /// </summary>
        public static LocalisableString UploadNewBeatmap => new TranslatableString(getKey(@"upload_new_beatmap"), @"Upload as a NEW level!");

        private static string getKey(string key) => $@"{prefix}:{key}";
    }
}
